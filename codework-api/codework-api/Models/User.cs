using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace codework_api.Models
{
    [Table("User")]
    public partial class User
    {
        public User()
        {
            UserEducations = new HashSet<UserEducation>();
            UserExperiences = new HashSet<UserExperience>();
            UserLogins = new HashSet<UserLogin>();
            UserSkills = new HashSet<UserSkill>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Guid { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(100)]
        public string ProfilePicture { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(20)]
        public string Contact { get; set; }
        [Required]
        public string Address { get; set; }
        public string Summary { get; set; }

        [InverseProperty(nameof(UserEducation.User))]
        public virtual ICollection<UserEducation> UserEducations { get; set; }
        [InverseProperty(nameof(UserExperience.User))]
        public virtual ICollection<UserExperience> UserExperiences { get; set; }
        [InverseProperty(nameof(UserLogin.User))]
        public virtual ICollection<UserLogin> UserLogins { get; set; }
        [InverseProperty(nameof(UserSkill.User))]
        public virtual ICollection<UserSkill> UserSkills { get; set; }
    }
}
