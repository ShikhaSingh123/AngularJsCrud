using AngularJsCrud.Contract;
using AngularJsCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;


namespace AngularJsCrud.Controllers
{
    public class SignUpController : ApiController
    {
        IEmployeeRepository repository;
        public SignUpController(IEmployeeRepository employeeRepository)
        {
            repository = employeeRepository;
        }

        [HttpPost]
        public bool Post(createUser createUser)
        {
            if (ModelState.IsValid)
            {
                return repository.CreateUser(createUser);
            }
            return false;
        }
    }
}
