using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventPlannerService.Common;
using EventPlannerService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventPlannerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly EventsContext _context;
        private IAuthHelper _authHelper;

        public UserController(EventsContext context, IAuthHelper authHelper)
        {
            _context = context;
            _authHelper = authHelper;
        }

        [HttpPost] // api/user
        public async Task<IActionResult> Signup(UserInfo userInfo)
        {
            if (userInfo != null && userInfo.Email != null && userInfo.Password != null)
            {
                var emailExists = await _context.UserInfo.FirstOrDefaultAsync(u => u.Email.Equals(userInfo.Email));
                if (emailExists != null) return Conflict("User already exists");

                _context.UserInfo.Add(userInfo);
                await _context.SaveChangesAsync();
                //return CreatedAtAction("GetUsers", new { id = userInfo.UserId }, userInfo);
                //return Created("http://localhost:61720/api/user", userInfo);
                //return userInfo.UserId;
                string accessToken = await _authHelper.getToken(userInfo);

                UserAndTokenData userAndTokenData = new UserAndTokenData(userInfo, accessToken);
                return StatusCode(201, userAndTokenData);
            }
            else
            {
                return BadRequest("Please enter all required fields");
            }
        }




        public async Task<ActionResult<UserInfo>> GetUsers(int id)
        {
            var user = await _context.UserInfo.FindAsync(id);


            if (user == null)
            {
                return NotFound();
            }

            return user;
        }


    }
}
