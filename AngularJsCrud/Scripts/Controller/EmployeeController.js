app.controller('EmployeeController', function ($scope, $http, $window) {

    //paging
    $scope.totalEmpList = [];
    $scope.currentIndex = 0;
    $scope.previousIndex = 0;
    $scope.limit = 5;
    $scope.empList = [];

    $scope.getNextData = function () {
        const totalLength = $scope.totalEmpList.length;
        if ($scope.currentIndex * $scope.limit < totalLength) {
            $scope.empList = $scope.totalEmpList.slice($scope.currentIndex * $scope.limit, ($scope.currentIndex * $scope.limit) + $scope.limit);
            $scope.previousIndex = $scope.currentIndex;
            $scope.currentIndex = $scope.currentIndex + 1;
        }
    }

    $scope.getPreviousData = function () {
        if ($scope.previousIndex > 0) {
            const totalLength = $scope.totalEmpList.length;
            if ($scope.previousIndex * $scope.limit < totalLength) {
                $scope.empList = $scope.totalEmpList.slice(($scope.previousIndex - 1) * $scope.limit, (($scope.previousIndex - 1) * $scope.limit) + $scope.limit);
                $scope.currentIndex = $scope.previousIndex;
                $scope.previousIndex = $scope.previousIndex >= 0 ? ($scope.previousIndex - 1) : $scope.previousIndex;
            }
        }
    }

    function getAllRecords() {
        const userId = sessionStorage.getItem('userId');
        $http.get('/api/Employee?id=' + userId).then(function (result) {
            $scope.totalEmpList = result.data;
            console.log($scope.totalEmpList);
            $scope.getNextData();
        });
    };

    getAllRecords();

    $scope.sortBy = '';
    $scope.sortDescending = false;

    $scope.editingData = {};

    $scope.addEmployee = function () {
        $window.location.href = '/CreateEmployee.html';
    }
    $scope.empSalary = function (id) {
        $window.location.href = '/EmpSalary.html?id=' + id;
    }
    $scope.EmployeeList = function () {
        $window.location.href = '/EmployeeList.html';
    }
    $scope.logOut = function () {
        $window.location.href = '/Index.html';
    }

    $scope.resetForm = function () {
        $scope.formData = {};
        $scope.myForm.$setPristine();
    };

    for (var i = 0, length = $scope.empList.length; i < length; i++) {
        $scope.editingData[$scope.empList[i].id] = false;
    }

    $scope.onEdit = function (emp) {
        $scope.editingData[emp.id] = true;
    }

    $scope.onUpdate = function (emp) {
        $http.put('/api/Employee', emp)
            .then(function (output) {
                if (output.data) {
                    alert('Updated Successfully');
                } else {
                    alert('Error in updating Data');
                };
            })
        $scope.editingData[emp.id] = false;
    }

    $scope.calSalary = function () {
        $scope.empInfo.Salary = '';
        $scope.empInfo.Salary = parseInt($scope.empInfo.Basic) + parseInt($scope.empInfo.Hra) + parseInt($scope.empInfo.Ta) + parseInt($scope.empInfo.Sa);
    }

    $scope.onCreate = function () {
        $http.post('/api/Employee', $scope.empInfo)
            .then(function (output) {
                if (output.data) {
                    getAllRecords();
                    $window.location.href = '/EmployeeList.html';
                    alert('Saved Successfully');
                } else {
                    alert('Error in Saving Data');
                };
            })
    };

    $scope.onDelete = function (id) {
        $http.delete('/api/Employee?id=' + id)
            .then(function (output) {
                if (output.data) {
                    alert('Successfully Deleted');
                    getAllRecords();
                } else {
                    alert('Error in Deleting Data');
                };
            })
    }
});