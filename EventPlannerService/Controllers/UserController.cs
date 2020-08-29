using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public UserController(EventsContext context)
        {
            _context = context;
        }

        [HttpPost] // api/user
        public async Task<ActionResult<UserInfo>> Signup(UserInfo userInfo)
        {
            var emailExists = await _context.UserInfo.FirstOrDefaultAsync(u => u.Email.Equals(userInfo.Email));
            if (emailExists != null) return Conflict("User already exists");



            _context.UserInfo.Add(userInfo);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetUsers", new { id = userInfo.UserId }, userInfo);

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
