using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CalculatorBack.Models;
using System.Web.Mvc;

namespace CalculatorBack.Controllers
{
    public class AuthenticationController : ApiController
    {
        private CalculatorEntities db = new CalculatorEntities();
        [ResponseType(typeof(User))]
        public IHttpActionResult Authenticate(User user)
        {
            var L2EQuery = db.Users.Where(s => s.userName == user.userName);
          
                User userFound = L2EQuery.FirstOrDefault<User>();
            
            
            if (userFound == null)
            {

                return Json(new { success = false, message = "incorrect UserName or password" });
            }
            else if (userFound.Password == user.Password)
            {

                return Ok(userFound);
            }
            return Json(new { success = false, message = "incorrect UserName or password" });

        }
        // GET: api/Authentication/username
       

    }

}