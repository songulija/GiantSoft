using AutoMapper;
using GiantSoft.Data;
using GiantSoft.ModelsDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiantSoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        //context for UserManager and SignInManager is ApiUser or whatever custom class you would have used
        //class that you set up in Startup. UserManager uses access to bunch of functions, that allows Signing,retriving user info, add users
        //so we dont have to write custom code for users tables. we can just inject any of those services like this. like Userroles too
        private readonly UserManager<ApiUser> _userManager;
        private readonly IMapper _mapper;
        private readonly ILogger<AccountsController> _logger;

        public AccountsController(UserManager<ApiUser> userManager, IMapper mapper, ILogger<AccountsController> logger)
        {
            _userManager = userManager;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// In Register we'll requiring sensitive data like passwords we dont want to send them as parameters
        /// We use POST request. when we do get request its sent accross in plain text. Get info from body
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
        {
            _logger.LogInformation($"Registration Attempt for {userDTO.Email}");
            //check if it's valid state. if you didnt include email or smth,
            //according to our standarts that we set in dto
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //map/convert userDTO object to ApiUser domain object(for database)
            var user = _mapper.Map<ApiUser>(userDTO);
            //ApiUser has Username not email
            user.UserName = userDTO.Email;
            //_userManager createAsync method will automatically hash password, store everything. 
            var result = await _userManager.CreateAsync(user, userDTO.Password);
            //check if registration succeded
            if (!result.Succeeded)
            {
                //for each error addModelError with status code and description
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            //if user was added we can add list of Roles to him
            await _userManager.AddToRolesAsync(user, userDTO.Roles);

            //return anything in 200 range. means it was succesful
            return Accepted();
        }


    }
}
