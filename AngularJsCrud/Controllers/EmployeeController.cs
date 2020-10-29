using AngularJsCrud.Models;
using System.Collections.Generic;
using System.Web.Http;
using AngularJsCrud.Contract;
using System;

namespace AngularJsCrud.Controllers
{
    public class EmployeeController : ApiController
    {
        IEmployeeRepository repository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            repository = employeeRepository;
        }

        [HttpGet]
        public List<EmployeeInfo> GetEmployeeInfo(int id)
        {

            return repository.GetEmployeeById(id);
        }
        [HttpPost]
        public bool Post(EmployeeInfo employeeInfo)
        {
            if (ModelState.IsValid)
            {
                //var Session = System.Web.HttpContext.Current.Session;
                //int id = Convert.ToInt32(Session["userId"]);
                return repository.CreateEmployee(employeeInfo);
            }
            return false;
        }

        public bool Put(EmployeeInfo employeeInfo)
        {
            if (ModelState.IsValid)
            {
                return repository.UpdateEmployee(employeeInfo);
            }
            return false;
        }
        public bool Delete(int id)
        {

            if (ModelState.IsValid)
            {
                return repository.DeleteEmployee(id);
            }
            return false;
        }
    }
}
