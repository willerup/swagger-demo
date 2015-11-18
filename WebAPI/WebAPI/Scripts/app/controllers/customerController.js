'use strict';
angular.module('myapp')

.controller('CustomerController', ['$scope', 'apiService', function ($scope, apiService) {

    function loadCustomers() {
        apiService.listCustomers().then(function (list) {
            $scope.customers = list;
        });
    }

    $scope.remove = function (customer) {
        apiService.deleteCustomer({ customerId: customer.id }).then(function () {
            loadCustomers();
        });
    };

    loadCustomers();
}])

.controller('AddCustomerController', ['$scope', '$state', 'apiService', function ($scope, $state, apiService) {

    $scope.addCustomer = function () {
        apiService.createCustomer({ customer: $scope.customer }).then(function () {
            $state.go('customers');
        });

    }

}]);