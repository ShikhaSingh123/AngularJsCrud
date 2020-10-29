app.controller('EmpSalaryController', function ($scope, $http, $window, $location) {

    getAllRecords();
    var Id = "";
    $scope.basic = "";
    $scope.hra = "";
    $scope.ta = "";
    $scope.sa = "";
    $scope.total = "";

    function getAllRecords() {
        var str = $location.absUrl();
        Id = str.split('=')[1];
        $http.get('/api/EmpSalary?id=' + Id).then(function (result) {
            $scope.basic = result.data.Basic;
            $scope.hra = result.data.Hra;
            $scope.ta = result.data.Ta;
            $scope.sa = result.data.Sa;
            $scope.total = result.data.Salary;
        });
    }

    $scope.calSalary = function () {
        $scope.total = '';
        $scope.total = parseInt($scope.basic) + parseInt($scope.hra) + parseInt($scope.ta) + parseInt($scope.sa);
    }

    $scope.onEdit = function () {
        var str = $location.absUrl();
        Id = str.split('=')[1];
        var dataObj = new Object();
        dataObj.Id = Id;
        dataObj.Basic = $scope.basic;
        dataObj.Hra = $scope.hra;
        dataObj.Ta = $scope.ta;
        dataObj.Sa = $scope.sa;
        dataObj.Salary = $scope.total;
        $http.put('/api/EmpSalary', dataObj)
            .then(function (output) {
                if (output.data) {
                    alert('Updated Successfully');
                    $window.location.href = '/EmployeeList.html';
                } else {
                    alert('Error in updating Data');
                };
            })
    }
});