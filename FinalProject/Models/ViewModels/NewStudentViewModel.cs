using System;
using System.ComponentModel.DataAnnotations;

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