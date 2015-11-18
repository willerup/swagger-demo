'use strict';
angular.module('myapp')

.controller('CustomerController', ['$scope', 'customerService', function ($scope, customerService) {

    function loadCustomers() {
        customerService.listCustomers().then(function (response) {
            $scope.customers = JSON.parse(JSON.stringify(response.data));;
        });
    }

    $scope.remove = function (customer) {
        customerService.deleteCustomer(customer.id).then(function () {
            loadCustomers();
        });
    };

    loadCustomers();
}])

.controller('AddCustomerController', ['$scope', '$state', 'customerService', function ($scope, $state, customerService) {

    $scope.addCustomer = function () {
        customerService.createCustomer($scope.customer).then(function () {
            $state.go('customers');
        });

    }

}]);