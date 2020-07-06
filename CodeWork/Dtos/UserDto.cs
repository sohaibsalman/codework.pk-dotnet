using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeWork.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public UserProfileDto Profile { get; set; }
    }
}