using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeWork.Models
{
    public class UserEducation
    {
        public int Id { get; set; }

        public DegreeTitle DegreeTitle { get; set; }

        public byte DegreeTitleId { get; set; }

        public string InstitutionName { get; set; }

        public string Location { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public double Grade { get; set; }
    }
}