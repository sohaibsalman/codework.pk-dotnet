﻿using CodeWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeWork.ViewModels
{
    public class JobInfoViewModel
    {
        public UserJobExperience Experience { get; set; }

        public IEnumerable<Industry> Industries { get; set; }
    }
}