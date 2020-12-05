using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace codework_api.Models
{
    [Table("Company")]
    public partial class Company
    {
        public Company()
        {
            UserExperiences = new HashSet<UserExperience>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Guid { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [InverseProperty(nameof(UserExperience.Company))]
        public virtual ICollection<UserExperience> UserExperiences { get; set; }
    }
}
