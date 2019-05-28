using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using luma.Models;
using Microsoft.IdentityModel.Tokens;

namespace luma.Controllers
{
    [RoutePrefix("auth")]
    [EnableCors("http://localhost:4200",headers:"*",methods:"*")]
    public class AuthenticationController : ApiController
    {
        private LabModels db;

        public AuthenticationController()
        {
            db = new LabModels();
        }

      [Route("register")]
        [HttpPost]
        public IHttpActionResult Register([FromBody] User user)
        {
            var u = db.Users.Any(c => c.userName == user.userName);

            if (u)
            {
                return BadRequest("User already exists, choose a different username");
            }

            db.Users.Add(user);
            db.SaveChanges();
            return Ok(CreateToken(user));
        }

        [Route("login")]
        [HttpPost]
        public IHttpActionResult LoginUser([FromBody] User user)
        {
            var u = db.Users.SingleOrDefault(c => c.userName == user.userName);

            if (u != null)
            {
                if (u.userPassword == user.userPassword)
                {
                    return Ok(CreateToken(user));
                }

            }
            
            return BadRequest("Wrong username or password");
        }

        private JwtPackage CreateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var claims = new ClaimsIdentity(new[] {new Claim(ClaimTypes.Email, user.userName)});
            const string securityKeyValue = "random_words_for_the_security_key";
            var securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(securityKeyValue));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var token = tokenHandler.CreateJwtSecurityToken(subject: claims,signingCredentials: signingCredentials);
            var tokenString = tokenHandler.WriteToken(token);

            return new JwtPackage()
            {
                userName = user.userName,
                token = tokenString
            };
        }
        

        // GET: api/Authentication
        public IQueryable<User> GetUsers()
        {
            return db.Users;
        }

        // GET: api/authentication/1
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT:  api/authentication/1
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.id)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST:  api/authentication
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(user);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = user.id }, user);
        }

        // DELETE:  api/authentication/1
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.id == id) > 0;
        }
    }


    class JwtPackage
    {
        public string userName { get; set; }
        public string token { get; set; }

    }
}