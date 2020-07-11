using CodeWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeWork.ViewModels
{
    public class PesronalInfoViewModel
    {
        public string Email { get; set; }

        public string Username { get; set; }

        public UserProfile Profile { get; set; }
    }
}