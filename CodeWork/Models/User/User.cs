using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeWork.Models
{
    public class User
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(127)]
        public string Username { get; set; }

        [Required]
        [StringLength(127)]
        public string Email { get; set; }

        [Required]
        [StringLength(127)]
        public string Password { get; set; }

        public UserProfile Profile { get; set; }
    }
}