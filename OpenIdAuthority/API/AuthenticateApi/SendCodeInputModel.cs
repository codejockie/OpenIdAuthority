﻿// Copyright (c) Ryan Foster. All rights reserved. 
// Licensed under the Apache License, Version 2.0.

using System.ComponentModel.DataAnnotations;

namespace SimpleIAM.OpenIdAuthority.API.AuthenticateApi
{
    public class SendCodeInputModel
    {
        [Required]
        public string Username { get; set; }
        public string ContinueUrl { get; set; }
    }
}
