using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DAL_DevoYard;
using Omar_Devoyard_v1.Models.Users;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace Omar_Devoyard_v1.Controllers
{
    public class AccountController : BaseController  // Inherit from BaseController instead of Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context) : base()  // Call base constructor if needed
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.SingleOrDefault(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    // Set the user's information in the session
                    HttpContext.Session.SetString("UserId", user.Id.ToString());
                    HttpContext.Session.SetString("UserName", $"{user.FirstName} {user.LastName}");

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                }
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Logout()
        { 
                HttpContext.Session.Clear();
                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction("Login", "Account");
            }

        }
    }

