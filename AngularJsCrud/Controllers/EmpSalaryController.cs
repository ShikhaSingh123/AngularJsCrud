using AngularJsCrud.Contract;
using AngularJsCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AngularJsCrud.Controllers
{
    public class EmpSalaryController : ApiController
    {
        IEmployeeRepository repository;

        public EmpSalaryController(IEmployeeRepository employeeRepository)
        {
            repository = employeeRepository;
        }

        [HttpGet]
        public EmpSal GetEmployeeInfo(int id)
        {
            return repository.GetSalaryById(id);
        }
        public bool Put(EmpSal empSal)
        {

            if (ModelState.IsValid)
            {
                return repository.UpdateSalary(empSal);
            }
            return false;
        }
    }
}
