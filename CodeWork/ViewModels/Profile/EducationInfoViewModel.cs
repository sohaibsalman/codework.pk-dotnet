using CodeWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeWork.ViewModels
{
    public class EducationInfoViewModel
    {
        public int ProfileId { get; set; }

        public UserEducation Education { get; set; }

        public IEnumerable<DegreeTitle> DegreeTitles { get; set; }
    }
}