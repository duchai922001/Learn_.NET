﻿namespace Learn_Net.DTOs
{
    public class RegisterRequest 
    { 
        public string FullName { get; set; } = null!; 
        public string Email { get; set; } = null!; 
        public string Password { get; set; } = null!; 
    }
}
