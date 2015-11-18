'use strict';

var app = angular.module('myapp', ['ui.router', 'api']);

app.config(function($stateProvider, $urlRouterProvider) {
    
    $urlRouterProvider.otherwise('/customers');

    $stateProvider
        .state('customers', {
            url: '/customers',
            templateUrl: 'scripts/app/views/customers.html',
            controller: 'CustomerController'
        })
        .state('addCustomer', {
            url: '/add-customer',
            templateUrl: 'scripts/app/views/add-customer.html',
            controller: 'AddCustomerController'
        });
});