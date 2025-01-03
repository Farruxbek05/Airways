﻿using System.ComponentModel.DataAnnotations;

namespace Airways.Application.Models.User
{
    public class UserResponceModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        Role role { get; set; }
    }
}
