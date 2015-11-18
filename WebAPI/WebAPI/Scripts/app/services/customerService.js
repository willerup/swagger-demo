
angular.module('myapp')
    .factory('customerService', ['api', function (api) {

        return {
            listCustomers: function() {
                return api.then(function(swagger) {
                    return swagger.public.listCustomers();
                });
            }
        };
    }]);