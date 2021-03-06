﻿// Copyright (c) Ryan Foster. All rights reserved. 
// Licensed under the Apache License, Version 2.0.

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleIAM.OpenIdAuthority.Orchestrators
{
    public class RegisterInputModel
    {
        public string ApplicationId { get; set; }

        [Required]
        [EmailAddress]
        [RegularExpression(@".+\@.+\..+", ErrorMessage = "Enter a valid email address")]
        public string Email { get; set; }

        public Dictionary<string, string> Claims {get; set;}

        public Dictionary<string, string> MailMergeValues {get; set;}

        public bool InviteToSetPasword { get; set; } = true;

        public string NextUrl { get; set; }
    }
}
