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
    public class EmpLoginController : ApiController
    {
        IEmployeeRepository repository;
        public EmpLoginController(IEmployeeRepository employeeRepository)
        {
            repository = employeeRepository;
        }
        [HttpPost]
        public LoginInfo validateLogin(LoginInfo loginInfo)
        {

            if (loginInfo.userName != null && loginInfo.password != null)
            {
                return repository.OnLogin(loginInfo);
            }
            return loginInfo;
        }
       

    }
}
