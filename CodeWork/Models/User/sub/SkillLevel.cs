using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeWork.Models
{
    public class SkillLevel
    {
        [Required]
        [Display(Name = "Skill Level")]
        public byte Id { get; set; }

        public string Name { get; set; }
    }
}