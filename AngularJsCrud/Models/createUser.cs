using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJsCrud.Models
{
    public class createUser
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string password { get; set; }
        public string emailId { get; set; }
        public string phoneNo { get; set; }
        public bool isAdmin { get; set; }
    }
}