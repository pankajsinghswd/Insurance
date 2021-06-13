using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Insurance.Utils;

namespace Insurance.Models
{
    public class GeneralModel : ResponseStatusCode
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}