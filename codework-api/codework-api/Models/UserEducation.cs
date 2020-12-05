using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace codework_api.Models
{
    [Table("User_Education")]
    public partial class UserEducation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Guid { get; set; }
        public int UserId { get; set; }
        [Required]
        [StringLength(50)]
        public string Location { get; set; }
        public double? Grade { get; set; }
        [Column(TypeName = "date")]
        public DateTime StartYear { get; set; }
        [Column(TypeName = "date")]
        public DateTime EndYear { get; set; }
        public int InstitutionId { get; set; }
        public int DegreeId { get; set; }
        public int FieldId { get; set; }
        public bool IsStudying { get; set; }

        [ForeignKey(nameof(DegreeId))]
        [InverseProperty("UserEducations")]
        public virtual Degree Degree { get; set; }
        [ForeignKey(nameof(FieldId))]
        [InverseProperty("UserEducations")]
        public virtual Field Field { get; set; }
        [ForeignKey(nameof(InstitutionId))]
        [InverseProperty("UserEducations")]
        public virtual Institution Institution { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("UserEducations")]
        public virtual User User { get; set; }
    }
}
