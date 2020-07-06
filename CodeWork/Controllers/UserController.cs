using AutoMapper;
using CodeWork.Models;
using CodeWork.ViewModels;
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

            var viewModel = GetProfileViewModel(_context, currentUser.Id);

            return View(viewModel);
        }



        //[HttpPost]
        //[ActionName("Profile")]
        //public ActionResult SavePersonalData(UserProfile profile)
        //{
        //    if (!ModelState.IsValid)
        //        return View("PersonalInfoForm");

        //    if (Session["user"] == null)
        //        return RedirectToAction("Login", "User");

        //    SessionData sessionData = (SessionData)Session["user"];

        //    //Create DB variable
        //    var _context = new ApplicationDbContext();

        //    var userInDb = _context.User.Include(p => p.Profile).Single(u => u.Id == sessionData.Id);

        //    userInDb.Profile = profile;

        //    //Add User Profile data to DB
        //    _context.SaveChanges();

        //    return View();
        //}


        [HttpPost]
        public new ActionResult Profile(PesronalInfoViewModel model, string info)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = GetProfileViewModel(new ApplicationDbContext(), ((SessionData)Session["user"]).Id);
                return View("Profile", viewModel);
            }

            using (var _context = new ApplicationDbContext())
            {
                SessionData currentUser = (SessionData)Session["user"];


                if(info == "personal")
                {
                    var profile = _context.UserProfile.Single(p => p.Id == model.Profile.Id);
                   
                    profile.Name = model.Profile.Name;
                    profile.ProfilePicture = model.Profile.ProfilePicture;
                    profile.Address = model.Profile.Address;
                    profile.ContactNumber = model.Profile.ContactNumber;
                    profile.DateOfBirth = model.Profile.DateOfBirth;
                    profile.Gender = model.Profile.Gender;
                    profile.Location = model.Profile.Location;
                }

                _context.SaveChanges();


                var viewModel = GetProfileViewModel(_context, currentUser.Id);

                return View("Profile", viewModel);
            }
        }

        [NonAction]
        private ProfileViewModel GetProfileViewModel(ApplicationDbContext _context, int id)
        {
            var userData = _context.User.Include(p => p.Profile).Single(u => u.Id == id);
            var degreeTitles = _context.DegreeTitles.ToList();
            var industries = _context.Industries.ToList();
            var skillLevel = _context.SkillLevels.ToList();

            ProfileViewModel viewModel = new ProfileViewModel
            {
                User = userData,
                DegreeTitles = degreeTitles,
                Industries = industries,
                SkillLevels = skillLevel
            };

            return viewModel;
        }
    }
}