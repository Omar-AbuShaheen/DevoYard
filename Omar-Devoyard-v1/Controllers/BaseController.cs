using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;

namespace Omar_Devoyard_v1.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            Initialize(context);
        }

        protected void Initialize(ActionExecutingContext context)
        {
            var userName = HttpContext.Session.GetString("UserName");

            // If user is not authenticated or session has expired, redirect to login page
            if (string.IsNullOrEmpty(userName) && !context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = RedirectToAction("Login", "Account");
            }
            else
            {
                ViewBag.UserName = userName;
            }
        }
    }
}
