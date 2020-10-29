using AngularJsCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJsCrud.Contract
{
    public interface IEmployeeRepository
    {
        int OnLogin(LoginInfo loginInfo);
        bool CreateUser(createUser createUser);
        List<EmployeeInfo> GetEmployeeById(int id);
        bool CreateEmployee(EmployeeInfo employeeInfo);
        bool UpdateEmployee(EmployeeInfo employeeInfo);
        EmpSal GetSalaryById(int id);
        bool UpdateSalary(EmpSal empSal);
        bool DeleteEmployee(int id);
    }
}
