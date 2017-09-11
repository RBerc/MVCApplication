using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCApplication.Models.ViewModel
{
    public class UserSignupView
    {
        [Key]
        public int SysUserId { get; set; }
        public int LOOKUPROleID { get; set; }
        public string RoleName { get; set; }
        [Required(ErrorMessage ="*")]
        [Display (Name ="Login Id")]
        public string LoginName { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Gender { get; set; }

    }
}