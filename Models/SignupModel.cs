﻿using System.ComponentModel.DataAnnotations;

namespace bookstore.Models
{
    public class SignupModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        
        public string Email { get; set; }
        [Required]
        [Compare("ConfirmPassword")]
        public string Password { get; set; }
        
        [Required]
        public string ConfirmPassword { get; set; }
    }
}
