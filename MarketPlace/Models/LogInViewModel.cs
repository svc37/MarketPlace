using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MarketPlace.Models
{
    public class LogInViewModel
    {
        [Required]
        public int Id { get; set; }

        public int CompanyId { get; set; }

        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }


        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        public string PasswordText { get; set; }

        public byte[] PasswordByte { get; set; }


        public byte[] Salt { get; set; }

    }
}