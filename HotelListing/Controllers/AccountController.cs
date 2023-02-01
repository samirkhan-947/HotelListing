﻿using AutoMapper;
using HotelListing.Data;
using HotelListing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApiUser> _userManager;
        //private readonly SignInManager<ApiUser> _signInManager;
        private readonly ILogger<AccountController> _Logger;
        private readonly IMapper _mapper;
        public AccountController(UserManager<ApiUser> userManager, /*SignInManager<ApiUser> signInManager,*/
            ILogger<AccountController> Logger, IMapper mapper)
        {
            _userManager = userManager;
            //_signInManager = signInManager;
            _Logger = Logger;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
        {
            _Logger.LogInformation($"Register Attempt for {userDTO.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var user = _mapper.Map<ApiUser>(userDTO);
                user.UserName = userDTO.Email;
                var result = await _userManager.CreateAsync(user, userDTO.Password);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest($"User Registraion Attempt Failed");
                }
                return Accepted();
            }
            catch (Exception ex)
            {
                _Logger.LogError(ex, $"Something went wrong in the {nameof(Register)}");
                return Problem($"Something went wrong in the {nameof(Register)}", statusCode: 500);
                
            }
           
        }
        //[HttpPost]
        //[Route("login")]
        //public async Task<IActionResult> Login(LoginUserDTO loginUserDTO) 
        //{
        //    _Logger.LogInformation($"Login Attempt for {loginUserDTO.Email}");

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    try
        //    {
        //        var user = _mapper.Map<ApiUser>(loginUserDTO);
        //        var result = await _signInManager.PasswordSignInAsync(loginUserDTO.Email,loginUserDTO.Password,false,false);

        //        if (!result.Succeeded)
        //        {
        //            return Unauthorized(loginUserDTO);
        //        }
        //        return Accepted();
        //    }

        //    catch (Exception ex)
        //    {

        //        _Logger.LogError(ex, $"Something went wrong in the {nameof(Login)}");
        //        return Problem($"Something went wrong in the {nameof(Login)}", statusCode: 500);
        //    }
            
        //} 
    }
}
