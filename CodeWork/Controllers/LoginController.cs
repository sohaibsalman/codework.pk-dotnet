using AutoMapper;
using CodeWork.Dtos;
using CodeWork.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeWork.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public new ActionResult User()
        {
            return View();
        }

        [HttpPost]
        public new ActionResult User(UserLoginDto user)
        {
            if (!ModelState.IsValid)
                return View();

            //Get User Data from DB
            var _context = new ApplicationDbContext();
            var userInDb = _context.User.Include(p => p.Profile).SingleOrDefault(u => u.Username == user.Username);

            //Invalid User-name entered
            if (userInDb == null)
                return HttpNotFound();

            //User-name found, validate password
            if(userInDb.Password == user.Password)
            {
                //Password is correct, add user id and user-name to session
                SessionData sessionData = Mapper.Map<SessionData>(userInDb);

                Session["user"] = sessionData;

                // see if user profile has null value in db?
                //if yes, redirect to profile page to complete the profile
                if (userInDb.Profile == null)
                    return RedirectToAction("Profile", "User", new { route = "personal" });

                return RedirectToAction("Index", "User"); 
            }

            return HttpNotFound();
        }

        public ActionResult Logout()
        {
            Session.RemoveAll();
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}