using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeWork.Models
{
    public class UserJobExperience
    {
        public int Id { get; set; }
     
        [Required]
        [StringLength(255)]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        public Industry Industry { get; set; }

        [Required]
        [Display(Name = "Industry Name")]
        public byte IndustryId { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "City")]
        public string Location { get; set; }

        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        public bool IsCurrentlyWorking { get; set; }
    }
}