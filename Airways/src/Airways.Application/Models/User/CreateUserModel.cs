﻿namespace Airways.Application.Models.User;

public class CreateUserModel
{
    public int ID { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    Role role { get; set; }
}

public class CreateUserResponceModel : BaseResponceModel { }
enum Role
{
    admin,
    customer
}