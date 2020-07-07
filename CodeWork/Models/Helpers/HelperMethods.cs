using CodeWork.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeWork.Models.Helpers
{
    public class HelperMethods
    {
        public static int GetProfileCompletionPercent(User user)
        {

            if (user.Profile == null)
                return 10;

            int percent = 0;
            if (user.Email != null)
                percent += 10;

            if (user.Profile.ProfilePicture != null)
                percent += 10;

            if (user.Profile.Summary != null)
                percent += 10;

            if (user.Profile.Education.Count != 0)
                percent += 20;

            if (user.Profile.Experience.Count != 0)
                percent += 20;

            if (user.Profile.Skills.Count != 0)
                percent += 15;

            return percent;
        }

        public static List<string> GetListOfIncompleteInfo(User user)
        {
            List<string> list = new List<string>();

            if (user.Email == null)
                list.Add("Personal Info");

            if (user.Profile.ProfilePicture == null)
                list.Add("Profile Picture");


            if (user.Profile.Summary == null)
                list.Add("Professional Summary");

            if (user.Profile.Education.Count == 0)
                list.Add("Education");

            if (user.Profile.Experience.Count == 0)
                list.Add("Job Experience");

            if (user.Profile.Skills.Count == 0)
                list.Add("Skills");

            return list;
        }

        public static List<string> GetListOfCompleteInfo(User user)
        {
            List<string> list = new List<string>();

            if (user.Email != null)
                list.Add("Personal Info");

            if (user.Profile.ProfilePicture != null)
                list.Add("Profile Picture");


            if (user.Profile.Summary != null)
                list.Add("Professional Summary");

            if (user.Profile.Education.Count != 0)
                list.Add("Education");

            if (user.Profile.Experience.Count != 0)
                list.Add("Job Experience");

            if (user.Profile.Skills.Count != 0)
                list.Add("Skills");

            return list;
        }

    }
}