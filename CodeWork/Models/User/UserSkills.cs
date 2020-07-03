using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeWork.Models
{
    public class UserSkills
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public SkillLevel SkillLevel { get; set; }
    }
}