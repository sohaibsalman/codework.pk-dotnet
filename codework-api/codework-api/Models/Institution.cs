using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace codework_api.Models
{
    [Table("Institution")]
    public partial class Institution
    {
        public Institution()
        {
            UserEducations = new HashSet<UserEducation>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Guid { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [InverseProperty(nameof(UserEducation.Institution))]
        public virtual ICollection<UserEducation> UserEducations { get; set; }
    }
}
