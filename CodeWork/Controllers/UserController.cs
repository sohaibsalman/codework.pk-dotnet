using CodeWork.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using System.Web.Mvc;

namespace CodeWork.Controllers
{
    [UserSessionCheck]
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public new ActionResult Profile(string route)
        {
            if(route != null)
            {
                if (route.Trim().ToLower() == "personal")
                    return View("PersonalInfoForm");

                if (route.Trim().ToLower() == "education")
                    return View("EducationInfo");

                if (route.Trim().ToLower() == "experience")
                    return View("ExperienceInfo");

                if (route.Trim().ToLower() == "skills")
                    return View("SkillsInfo");
            }

            //Get info of logged in user
            SessionData currentUser = (SessionData)Session["user"];

            //Create Db variable
            ApplicationDbContext _context = new ApplicationDbContext();

            User userData = _context.User.Include(p => p.Profile).Single(u => u.Id == currentUser.Id);

            return View(userData);
        }



        [HttpPost]
        [ActionName("Profile")]
        public ActionResult SavePersonalData(UserProfile profile)
        {
            if (!ModelState.IsValid)
                return View("PersonalInfoForm");

            if (Session["user"] == null)
                return RedirectToAction("Login", "User");

            SessionData sessionData = (SessionData)Session["user"];

            //Create DB variable
            var _context = new ApplicationDbContext();

            var userInDb = _context.User.Include(p => p.Profile).Single(u => u.Id == sessionData.Id);

            userInDb.Profile = profile;

            //Add User Profile data to DB
            _context.SaveChanges();

            return View();
        }
    }
}