using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace codework_api.Models
{
    [Table("User_Experience")]
    public partial class UserExperience
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Guid { get; set; }
        public int UserId { get; set; }
        [Required]
        [StringLength(100)]
        public string JobTitle { get; set; }
        public int CompanyId { get; set; }
        public int IndustryId { get; set; }
        public double? Salaray { get; set; }
        [Required]
        public string Location { get; set; }
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }
        public bool IsWorking { get; set; }
        public string Description { get; set; }

        [ForeignKey(nameof(CompanyId))]
        [InverseProperty("UserExperiences")]
        public virtual Company Company { get; set; }
        [ForeignKey(nameof(IndustryId))]
        [InverseProperty(nameof(WorkIndustry.UserExperiences))]
        public virtual WorkIndustry Industry { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("UserExperiences")]
        public virtual User User { get; set; }
    }
}
