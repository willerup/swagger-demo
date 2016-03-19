angular.module('demo', ['ngRoute'])
.config(function($routeProvider) {
    $routeProvider.when('/', {
        controller: 'DemoController',
        templateUrl: 'views/demo.html'
    });
});
