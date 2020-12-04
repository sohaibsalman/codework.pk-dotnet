using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace codework_api.Models
{
    [Table("User_Skills")]
    public partial class UserSkill
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Guid { get; set; }
        public int UserId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public int SkillTypeId { get; set; }

        [ForeignKey(nameof(SkillTypeId))]
        [InverseProperty("UserSkills")]
        public virtual SkillType SkillType { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("UserSkills")]
        public virtual User User { get; set; }
    }
}
