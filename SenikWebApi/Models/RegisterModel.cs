﻿namespace SenikWebApi.Models;

public class RegisterModel
{
    public string FullName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;       
}
