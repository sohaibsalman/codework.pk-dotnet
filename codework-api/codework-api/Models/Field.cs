using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace codework_api.Models
{
    [Table("Field")]
    public partial class Field
    {
        public Field()
        {
            UserEducations = new HashSet<UserEducation>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Guid { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [InverseProperty(nameof(UserEducation.Field))]
        public virtual ICollection<UserEducation> UserEducations { get; set; }
    }
}
