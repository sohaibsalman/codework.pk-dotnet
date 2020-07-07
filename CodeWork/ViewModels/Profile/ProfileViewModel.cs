using CodeWork.Dtos;
using CodeWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeWork.ViewModels
{
    public class ProfileViewModel
    {
        public User User { get; set; }

        public UserEducation Education { get; set; }

        public UserJobExperience Job { get; set; }

        public UserSkills Skills { get; set; }

        public IEnumerable<DegreeTitle> DegreeTitles { get; set; }

        public IEnumerable<Industry> Industries { get; set; }

        public IEnumerable<SkillLevel> SkillLevels { get; set; }
    }
}