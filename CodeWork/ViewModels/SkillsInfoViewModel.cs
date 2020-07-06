﻿using CodeWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeWork.ViewModels
{
    public class SkillsInfoViewModel
    {
        public UserSkills Skill { get; set; }

        public IEnumerable<SkillLevel> SkillLevels { get; set; }
    }
}