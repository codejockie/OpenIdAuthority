﻿// Copyright (c) Ryan Foster. All rights reserved. 
// Licensed under the Apache License, Version 2.0.

using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SimpleIAM.OpenIdAuthority.Orchestrators;

namespace SimpleIAM.OpenIdAuthority.API
{
    [Route("api/v1")]
    [EnableCors("CorsPolicy")]
    public class AuthenticateApiController : Controller
    {
        private readonly AuthenticateOrchestrator _authenticateOrchestrator;

        public AuthenticateApiController(AuthenticateOrchestrator authenticateOrchestrator)
        {
            _authenticateOrchestrator = authenticateOrchestrator;            
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterInputModel model)
        {
            if (ModelState.IsValid)
            {
                return (await _authenticateOrchestrator.RegisterAsync(model)).ToJsonResult();
            }
            return new ActionResponse(ModelState).ToJsonResult();
        }

        [HttpPost("send-one-time-code")]
        public async Task<IActionResult> SendOneTimeCode([FromBody] SendCodeInputModel model)
        {
            if (ModelState.IsValid)
            {
                return (await _authenticateOrchestrator.SendOneTimeCodeAsync(model)).ToJsonResult();
            }
            return new ActionResponse(ModelState).ToJsonResult();
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateInputModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _authenticateOrchestrator.AuthenticateCodeAsyc(model);
                if(response.StatusCode == 301)
                {
                    return await SignInAndReturnAsync(model.Username, model.StaySignedIn, response.RedirectUrl);
                }
                return response.ToJsonResult();
            }
            return new ActionResponse(ModelState).ToJsonResult();
        }

        [DisableCors]
        [HttpPost("authenticate-password")]
        public async Task<IActionResult> AuthenticatePassword([FromBody] AuthenticatePasswordInputModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _authenticateOrchestrator.AuthenticatePasswordAsync(model);
                if (response.StatusCode == 301)
                {
                    return await SignInAndReturnAsync(model.Username, model.StaySignedIn, response.RedirectUrl);
                }
                return response.ToJsonResult();
            }
            return new ActionResponse(ModelState).ToJsonResult();
        }

        [HttpPost("send-password-reset-message")]
        public async Task<IActionResult> SendPasswordResetMessage([FromBody]SendPasswordResetMessageInputModel model)
        {
            if (ModelState.IsValid)
            {
                return (await _authenticateOrchestrator.SendPasswordResetMessageAsync(model)).ToJsonResult();
            }
            return new ActionResponse(ModelState).ToJsonResult();
        }

        private async Task<IActionResult> SignInAndReturnAsync(string username, bool staySignedIn, string nextUrl)
        {
            await _authenticateOrchestrator.SignInUserAsync(HttpContext, username, staySignedIn);
            return new JsonResult(new
            {
                Message = (string)null,
                NextUrl = nextUrl
            });
        }
    }
}