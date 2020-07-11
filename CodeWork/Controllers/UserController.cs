using AutoMapper;
using CodeWork.Models;
using CodeWork.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
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
        public ActionResult UpdatePersonal(PesronalInfoViewModel model)
        {

            if (!ModelState.IsValid)
            {
                var vm = GetProfileViewModel(new ApplicationDbContext(), ((SessionData)Session["user"]).Id);
                return View("Profile", vm);
            }

            using (var _context = new ApplicationDbContext())
            {
                
                var profileInDb = _context.UserProfile.Single(p => p.Id == model.Profile.Id);

                if(Request.Files["profile-pic"] != null)
                {
                    var file = Request.Files["profile-pic"];

                    if(file.FileName != "")
                    {
                        string extension = System.IO.Path.GetExtension(file.FileName);

                        //Generate unique name
                        string uniqueName = model.Username + extension;

                        //Get root path
                        string rootPath = Server.MapPath("~/Img/Profile");

                        string fileSavePath = Path.Combine(rootPath, uniqueName);

                        //Save File
                        file.SaveAs(fileSavePath);

                        //Save profile pic name in db
                        profileInDb.ProfilePicture = uniqueName;
                    }
                }

                profileInDb.Name = model.Profile.Name;
                profileInDb.Address = model.Profile.Address;
                profileInDb.ContactNumber = model.Profile.ContactNumber;
                profileInDb.DateOfBirth = model.Profile.DateOfBirth;
                profileInDb.Gender = model.Profile.Gender;
                profileInDb.Location = model.Profile.Location;


                _context.SaveChanges();
            }
            var viewModel = GetProfileViewModel(new ApplicationDbContext(), ((SessionData)Session["user"]).Id);
            return View("Profile", viewModel);
        }

        [HttpPost]
        public ActionResult UpdateSummary(SummaryViewModel model)
        {
           
            if (!ModelState.IsValid)
            {
                var vm = GetProfileViewModel(new ApplicationDbContext(), ((SessionData)Session["user"]).Id);
                return View("Profile", vm);
            }

            using (var _context = new ApplicationDbContext())
            {
                //Get profile from Db
                var profileInDb = _context.UserProfile.Single(p => p.Id == model.ProfileId);

                //Update Summary
                profileInDb.Summary = model.Summary;

                //Save Changes
                _context.SaveChanges();
            }
            var viewModel = GetProfileViewModel(new ApplicationDbContext(), ((SessionData)Session["user"]).Id);
            return View("Profile", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateEducation(EducationInfoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var vm = GetProfileViewModel(new ApplicationDbContext(), ((SessionData)Session["user"]).Id);
                return View("Profile", vm);
            }

            using(var _context = new ApplicationDbContext())
            {
                //Get User profile from DB
                var profileInDb = _context.
                    UserProfile.
                    Include(e => e.Education).
                    SingleOrDefault(p => p.Id == model.ProfileId);

                //If there is no id, it means we have to add the education in db
                if (model.Education.Id == 0)
                    profileInDb.Education.Add(model.Education);

                _context.SaveChanges();
            }

            var viewModel = GetProfileViewModel(new ApplicationDbContext(), ((SessionData)Session["user"]).Id);
            return View("Profile", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateJob(JobInfoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var vm = GetProfileViewModel(new ApplicationDbContext(), ((SessionData)Session["user"]).Id);
                return View("Profile", vm);
            }

            using(var _context = new ApplicationDbContext())
            {
                //Get user profile from Db
                var profileInDb = _context.UserProfile.
                    Include(j => j.Experience).
                    SingleOrDefault(p => p.Id == model.ProfileId);

                //Check if profile is empty
                if (profileInDb == null)
                    return HttpNotFound();

                if (model.Experience.Id == 0)
                    profileInDb.Experience.Add(model.Experience);

                _context.SaveChanges();
            }

            var viewModel = GetProfileViewModel(new ApplicationDbContext(), ((SessionData)Session["user"]).Id);
            return View("Profile", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateSkills(SkillsInfoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var vm = GetProfileViewModel(new ApplicationDbContext(), ((SessionData)Session["user"]).Id);
                return View("Profile", vm);
            }


            using(var _context = new ApplicationDbContext())
            {

                //Get User profile from Db
                var profileInDb = _context.
                    UserProfile.
                    Include(s => s.Skills).
                    SingleOrDefault(p => p.Id == model.ProfileId);

                //Check if profile is null
                if (profileInDb == null)
                    return HttpNotFound();

                //Profile is not null, check if the skill id is 0, it means that new skill will be added to db
                if (model.Skill.Id == 0)
                    profileInDb.Skills.Add(model.Skill);

                _context.SaveChanges();
            }

            var viewModel = GetProfileViewModel(new ApplicationDbContext(), ((SessionData)Session["user"]).Id);
            return View("Profile", viewModel);
        }

        [NonAction]
        private ProfileViewModel GetProfileViewModel(ApplicationDbContext _context, int id)
        {
            var userData = _context.User.
                Include(p => p.Profile).
                Include(e => e.Profile.Education).
                Include(j => j.Profile.Experience).
                Include(s => s.Profile.Skills).
                Single(u => u.Id == id);
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