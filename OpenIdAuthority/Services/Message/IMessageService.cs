﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleIAM.OpenIdAuthority.Services.Message
{
    public interface IMessageService
    {
        Task<SendMessageResult> SendAccountNotFoundMessageAsync(string sendTo);
        Task<SendMessageResult> SendOneTimeCodeMessageAsync(string sendTo, string oneTimeCode);
        Task<SendMessageResult> SendOneTimeCodeAndLinkMessageAsync(string sendTo, string oneTimeCode, string longCode);
        Task<SendMessageResult> SendWelcomeMessageAsync(string clientId, string sendTo, string oneTimeCode, string longCode, IDictionary<string, string> additionalMailMergeValues);
        Task<SendMessageResult> SendPasswordResetMessageAsync(string clientId, string sendTo, string oneTimeCode, string longCode);
    }
}
