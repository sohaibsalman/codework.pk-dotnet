using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CodeWork.Models
{
    public class UserSessionCheck: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpSessionStateBase session = filterContext.HttpContext.Session;
            if (session != null && session["user"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                   new RouteValueDictionary {
                                { "Controller", "Login" },
                                { "Action", "User" }
                               });
            }
        }
    }
}