﻿namespace Airways.Application.Models.User
{
    public class UpdateUserModel
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        Role role { get; set; }
    }
  public class UpdateusrResponceModel : BaseResponceModel { }
}
