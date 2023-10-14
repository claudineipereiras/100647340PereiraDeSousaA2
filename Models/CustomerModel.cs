/* DESIGNER: Claudinei Pereira de Sousa (100647340)
   EXERCISE: Assignment 02
   TASK: Doonut Website - ASP.NET MVC Project */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _100647340PereiraDeSousaA2.Models
{
    public class CustomerModel
    {
        [Display(Name = "Customer ID")]
        [Range(100000, 999999, ErrorMessage = "Invalid Customer ID")]
        public int CustomerID { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        public int Phone { get; set; }

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Confirm Email")]
        [Compare("Email", ErrorMessage = "The Email is not matched!")]
        public string ConfirmEmail { get; set; }


        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "The Passowrd must be at least 6 Characters")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password ")]
        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The Password is not matched!")]
        public string ConfirmPassword { get; set; }


    }
}