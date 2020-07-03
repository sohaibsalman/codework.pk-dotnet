using AutoMapper;
using CodeWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeWork.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        // GET: Register/User
        public new ActionResult User()
        {
            return View();
        }

        [HttpPost]
        public new ActionResult User(User user)
        {
            if (!ModelState.IsValid)
                return View();

            //Create DB variable
            var _context = new ApplicationDbContext();

            //Add New user to db and save changes
            _context.User.Add(user);
            _context.SaveChanges();

            //Store data to session
            SessionData sessionData = Mapper.Map<SessionData>(user);
            Session["user"] = sessionData;

            //Redirect to Profile Page
            return RedirectToAction("Profile", "User", routeValues: new { rout = "personal"});
        }

    }
}