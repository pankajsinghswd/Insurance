using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insurance.Models.APIModels
{
    public class UserDetailsModels
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string RoleName { get; set; }
        public int RoleId { get; set; }
    }
}