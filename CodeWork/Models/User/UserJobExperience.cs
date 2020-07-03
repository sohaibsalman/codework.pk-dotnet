using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeWork.Models
{
    public class UserJobExperience
    {
        public int Id { get; set; }
        
        public string JobTitle { get; set; }
        
        public string CompanyName { get; set; }

        public Industry Industry { get; set; }

        public byte IndustryId { get; set; }

        public string Location { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool IsCurrentlyWorking { get; set; }
    }
}