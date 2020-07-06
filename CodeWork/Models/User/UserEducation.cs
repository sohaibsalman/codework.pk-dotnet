using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeWork.Models
{
    public class UserEducation
    {
        public int Id { get; set; }

        public DegreeTitle DegreeTitle { get; set; }

        [Required]
        [Display(Name = "Degree Title")]
        public byte DegreeTitleId { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Field of Study")]
        public string FieldOfStudy { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Institution Name")]
        public string InstitutionName { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "City")]
        public string Location { get; set; }

        [Display(Name = "Starting Date")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Ending Date")]
        public DateTime? EndDate { get; set; }

        public double? Grade { get; set; }
    }
}