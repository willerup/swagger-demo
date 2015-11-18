
angular.module('myapp')
    .factory('api', ['$q', function ($q) {

        var api = $q.defer();

        window.swagger = new SwaggerClient({
            url: "http://demo.local/content/swagger.json",
            usePromise: true
        }).then(function(client) {
            api.resolve(client);
        });

        return api.promise;
    }]);