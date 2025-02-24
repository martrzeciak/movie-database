﻿using System.ComponentModel.DataAnnotations;

namespace MovieDatabase.API.DTOs;

public class RegisterDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
