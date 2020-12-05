using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace codework_api.Models
{
    [Table("Skill_Type")]
    public partial class SkillType
    {
        public SkillType()
        {
            UserSkills = new HashSet<UserSkill>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Guid { get; set; }
        [Required]
        [StringLength(20)]
        public string Type { get; set; }

        [InverseProperty(nameof(UserSkill.SkillType))]
        public virtual ICollection<UserSkill> UserSkills { get; set; }
    }
}
