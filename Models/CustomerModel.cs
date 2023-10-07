/* DESIGNER: Claudinei Pereira de Sousa (100647340)
   EXERCISE: Assignment 02
   TASK: Doonut Website - ASP.NET MVC Project */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _100647340PereiraDeSousaA2.Models
{
    public class CustomerModel
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
    }
}