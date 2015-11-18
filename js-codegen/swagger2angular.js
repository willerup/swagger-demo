var fs = require('fs');
var CodeGen = require('swagger-js-codegen').CodeGen;

var file = 'swagger.json';
var swagger = JSON.parse(fs.readFileSync(file, 'UTF-8'));
var angularjsSourceCode = CodeGen.getAngularCode({ className: 'apiService', moduleName: 'api', swagger: swagger });
//console.log(nodejsSourceCode);
console.log(angularjsSourceCode);
