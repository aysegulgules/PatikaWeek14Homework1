﻿using System.ComponentModel.DataAnnotations;

namespace PatikaWeek14Homework1.Models
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}