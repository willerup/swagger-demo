
angular.module('myapp')
    .factory('customerService', ['$http', function ($http) {

        return {
            listCustomers: function() {
                return $http.get('/v1/customers');
            },
            createCustomer: function(customer) {
                return $http.post('/v1/customers', customer);
            },
            deleteCustomer: function(id) {
                return $http.delete('/v1/customers/' + id);
            }
        };
    }]);