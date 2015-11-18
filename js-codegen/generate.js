var fs = require('fs');
var CodeGen = require('swagger-js-codegen').CodeGen;

var file = 'spec.json';
var swagger = JSON.parse(fs.readFileSync(file, 'UTF-8'));
var nodejsSourceCode = CodeGen.getNodeCode({ className: 'MyProject', swagger: swagger });
var angularjsSourceCode = CodeGen.getAngularCode({ className: 'CustomerApi', moduleName: 'MyProject', swagger: swagger });
//console.log(nodejsSourceCode);
console.log(angularjsSourceCode);
