app.controller('SignUpController', function ($scope, $http, $window,) {

    $scope.createSignUp = function () {
        debugger;
        $http.post('/api/SignUp', $scope.signUp)
            .then(function (output) {
                if (output.data) {
                    $window.location.href = '/Index.html';
                    alert('User Created');
                } else {
                    alert('Error in Saving User');
                };
            })

    };
});