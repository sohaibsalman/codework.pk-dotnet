using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeWork.Models
{
    public class UserSkills
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Skill Name")]
        public string Name { get; set; }

        public SkillLevel SkillLevel { get; set; }

        [Required]
        [Display(Name = "Skill Level")]
        public int SkillLevelId { get; set; }
    }
}