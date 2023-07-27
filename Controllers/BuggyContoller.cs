using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.entities;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace API.Controllers
{
    public class BuggyContoller : BaseApiContoller
    {
        private readonly DataContext _context;

        public BuggyContoller(DataContext context)
        {
            _context = context;
        }
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "secret text";
        }
        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {
            var thing = _context.Users.Find(-1);
            
            if (thing == null) return NotFound();

            return thing;
        }
        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
            try 
            {
            var thing = _context.Users.Find(-1);

            var thingToReturn = thing.ToString();

            return thingToReturn;
            }
            catch (Exception ex) 
            {
                return StatusCode(500, "computer says no!");
            }
          

        }
        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("this was not a good request");
        }
        
    }

}