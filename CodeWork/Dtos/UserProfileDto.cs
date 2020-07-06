using CodeWork.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeWork.Dtos
{
    public class UserProfileDto
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        public string ProfilePicture { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }

        [Required]
        [Display(Name = "City")]
        public string Location { get; set; }

        public string Address { get; set; }

        public string Summary { get; set; }

        public ICollection<UserEducation> Education { get; set; }

        public ICollection<UserJobExperience> Experience { get; set; }

        public ICollection<UserSkills> Skills { get; set; }
    }
}