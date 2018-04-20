﻿// Copyright (c) Ryan Foster. All rights reserved. 
// Licensed under the Apache License, Version 2.0.

using System.ComponentModel.DataAnnotations;

namespace SimpleIAM.IdAuthority.UI.Account
{
    public class SignInViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }

        public int? SessionLengthMinutes { get; set; }

        public string LeaveBlank { get; set; }

        public string ClientName { get; set; }

        public bool SignInEmailSent { get; set; }
    }
}