﻿// Copyright (c) Ryan Foster. All rights reserved. 
// Licensed under the Apache License, Version 2.0.

using System.ComponentModel.DataAnnotations;

namespace SimpleIAM.OpenIdAuthority.UI.Authenticate
{
    public class SignInPassViewModel
    {
        [Required]
        [EmailAddress]
        [RegularExpression(@".+\@.+\..+", ErrorMessage = "Enter a valid email address")]
        public string Email { get; set; }

        public string Password { get; set; }

        public int? SessionLengthMinutes { get; set; }

        public string LeaveBlank { get; set; }

        public string ReturnUrl { get; set; }
    }
}