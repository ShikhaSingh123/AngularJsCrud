using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJsCrud.Models
{
    public class EmployeeInfo
    {
        public int id { get; set; }
        public string Empname { get; set; }
        public string Designation { get; set; }
        public string Location { get; set; }
        public int Userid { get; set; }
        public int Basic { get; set; }
        public int Hra { get; set; }
        public int Ta { get; set; }
        public int Sa { get; set; }
        public int Salary { get; set; }
    }
}