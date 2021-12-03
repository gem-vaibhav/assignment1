using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace assaignment.Models
{
    public class RegisterationRecord
    {   
        [Required(ErrorMessage ="Please enter this field")]
        public string First_Name { get; set; }

        [Required]
        public string Last_Name { get; set; }

        [Required]
        public Gender UserGender { get; set; }

        [Required]
        public string Email_address { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

    }

    public enum Gender
    {
        male,
        female
    }
}
