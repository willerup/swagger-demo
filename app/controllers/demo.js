angular.module('demo')
.controller('DemoController', function($scope, $http) {

    // $scope.customers = [{
    //     id: 123,
    //     name: 'Bob'
    // }, {
    //     id: 234,
    //     name: 'Cindy'
    // }];

    $http.get('http://localhost:8001/v1/customers').then(function(res) {
        console.log(res.data);
        $scope.customers = res.data.customers;
    })
});
