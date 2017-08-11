using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject.Models.ViewModels
{
    public class NewStudentViewModel
    {
        [Required]
        public Student Student { get; set; }
        [Required]
        [MaxLength(50)]
        public String ConfirmPassword { get; set; }
    }
}