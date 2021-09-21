using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class Manager
    {
        [Key]
        public int ManagerId { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }
    }
}