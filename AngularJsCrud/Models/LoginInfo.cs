using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJsCrud.Models
{
    public class LoginInfo
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public int status { get; set; }
        public string msg { get; set; }
        
    }
}