using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace CodeWork.Models
{
    public class UserProfile
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(127)]
        public string ProfilePicture { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }
        
        [Required]
        [StringLength(127)]
        [Display(Name = "City")]
        public string Location { get; set; }

        [StringLength(511)]
        public string Address { get; set; }

        [StringLength(1023)]
        public string Summary { get; set; }

        public ICollection<UserEducation> Education { get; set; }

        public ICollection<UserJobExperience> Experience { get; set; }

        public ICollection<UserSkills> Skills { get; set; }
    }

}