﻿// Copyright (c) Ryan Foster. All rights reserved. 
// Licensed under the Apache License, Version 2.0.

using System.Threading.Tasks;

namespace SimpleIAM.OpenIdAuthority.Services.Email
{
    public interface IEmailService
    {
        Task<SendMessageResult> SendEmailAsync(string from, string to, string subject, string body);
    }
}
