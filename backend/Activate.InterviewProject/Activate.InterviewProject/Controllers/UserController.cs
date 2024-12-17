using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Activate.InterviewProject.Core.Models;
using Activate.InterviewProject.Core.Models.Authentication;
using Activate.InterviewProject.Services;
using Activate.InterviewProject.Services.Interfaces;

namespace Activate.InterviewProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : Controller
    {

        public readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsersList()
        {
            var usersList = await _userService.GetAllUsers();
            if (usersList == null)
            {
                return NotFound();
            }
            return Ok(usersList);
        }


        [HttpGet("admin")]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetAdminUsers()
        {
            var usersList = await _userService.GetAdminUsers();
            if (usersList == null)
            {
                return NotFound();
            }
            return Ok(usersList);
        }


        [HttpGet("normal")]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetNormalUsers()
        {
            var usersList = await _userService.GetNormalUsers();
            if (usersList == null)
            {
                return NotFound();
            }
            return Ok(usersList);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<AppUser>> GetUserById(Guid userId)
        {
            var user = await _userService.GetUserById(userId);
            if (user == null) 
            {
                return BadRequest();
            }
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateUser(RegisterModel user)
        {
            var userCreated = await _userService.CreateUser(user);
            if (!userCreated)
            {
                return BadRequest();
            }
            return Ok(userCreated);    
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(User user)
        {
            if(user == null)
            {
                return BadRequest();
            }
            else
            {
                var userCreated = await _userService.UpdateUser(user);
                if (!userCreated)
                {
                    return BadRequest();
                }
                return Ok(userCreated);
            }
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            var userDeleted = await _userService.DeleteUser(userId);
            if (!userDeleted)
            {
                return BadRequest();
            }
            return Ok(userDeleted);
        }

        [HttpGet("roles")]
        public async Task<ActionResult<IEnumerable<UserRoles>>> GetUserRoles()
        {
            var roles = await _userService.GetAllUserRoles();
            if (roles == null || !roles.Any())
            {
                return NotFound();
            }
            return Ok(roles);
        }
    }
}
