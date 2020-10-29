app.controller('LoginController', function ($scope, $http, $window,) {

    $scope.OnLogin = function () {
        $http.post('/api/EmpLogin', $scope.login)
            .then(function (output) {
                console.log(output.data);
                if (output.data) {
                    sessionStorage.setItem("userId", output.data);                   
                    $window.location.href = '/EmployeeList.html';
                } else {
                    alert('Invalid Username/Password');
                };
            })
    }
    $scope.createUser = function () {
        $window.location.href = '/SignUp.html';
    }

});