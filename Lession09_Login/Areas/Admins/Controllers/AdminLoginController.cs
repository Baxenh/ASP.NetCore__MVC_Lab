﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;

namespace Lesson09_Login.Areas.Admins.Controllers
{
    [Area("Admins")]
    public class AdminLoginController : Controller
    {
       public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("AdminLogin") == null)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { Controller = "Login", Action = "Index", Areas = "Admins" }));
            }
            base.OnActionExecuting(context);
        }
    }
}
