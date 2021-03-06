
/*
* This imports an autogenerated csharp zip file from the swagger editor into the c# client project
*/


var fs = require('fs');
var replace = require('replace');
var rimraf = require('rimraf');
var ncp = require('ncp');
var exec = require('child_process').exec;

if (process.argv.length < 4) {
    console.log('usage: <source zip file> <csproj file>');
    process.exit();
}
var source = process.argv[2];
console.log('source zip file: ' + source);

var csproj = process.argv[3];
console.log('csproj file: ' + csproj);


var walk = function (dir, done) {
    var results = [];
    fs.readdir(dir, function (err, list) {
        if (err) return done(err);
        var i = 0;
        (function next() {
            var file = list[i++];
            if (!file) return done(null, results);
            file = dir + '/' + file;
            fs.stat(file, function (err, stat) {
                if (stat && stat.isDirectory()) {
                    walk(file, function (err, res) {
                        results = results.concat(res);
                        next();
                    });
                } else {
                    results.push(file);
                    next();
                }
            });
        })();
    });
};

rimraf('csharp-client', function () {
    exec('unzip.exe ' + source, function (error, stdout, stderr) {
        if (error) return console.log('Failed to unzip source files' + error);

        rimraf('../IO', function () {
            ncp('csharp-client/src/main/csharp', '..', function (err) {
                if (err) return console.log(err);
                console.log('.. copied in new IO files');

                // Update project file so that it has all the correct references
                walk('../IO', function (err, refs) {
                    if (err) return console.log(err);

                    var compile = "";
                    refs.forEach(function (ref) {
                        ref = ref.substring(3).replace(/\//g, '\\');
                        compile += "<Compile Include=\"" + ref + "\" />\n";
                    });

                    fs.readFile(csproj, 'utf8', function (err, file) {
                        if (err) return console.log(err);
                        file = file.replace(/^.*Compile.*Swagger.*$/gm, '');
                        file = file.replace(/(<Compile)/, compile + "$1");
                        fs.writeFile(csproj, file, 'utf8', function (err) {
                            if (err) return console.log(err);
                            console.log('.. updated ' + csproj);
                        });
                    });
                });
            });
        });
    });
});
