using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Exchange.WebServices.Data;
using RSS.Business.Interfaces;
using RSS.Business.Models;
using System.Security.Claims;

namespace RSS.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        const string SessionId = "_Id";
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: AccountController
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(UserModel model)
        {
            var message = _userService.Register(model);
            if (message == false)
            {
                TempData["message"] = "Email Already Registered";
                return View();
            }
            else
            {
                return RedirectToAction("LogIn");
            }
        }

        // GET: AccountController/Create
        public ActionResult LogIn()
        {
            return View();
        }

        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(UserModel model)
        {
            var user = _userService.Login(model);
            if(user != null)
            {
                var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, user.FullName) },
                    CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                HttpContext.Session.SetInt32(SessionId, user.Id);
                return RedirectToAction("Index", "Home");
                
            }
            else
            {
                TempData["message"] = "Account not Found";
                return View();
            }
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult ForgotPassword(UserModel model)
        {
            var user = _userService.FindEmail(model.Email,model.CNIC);
            if(user == false)
            {
                ViewData["error"] = "Email not Found";
                return View();
            }
            else
            {
                TempData["Email"] = model.Email;
                return RedirectToAction("ResetPassword");
            }
        }
        public ActionResult ResetPassword()
        {
            ViewData["Email"] = TempData["Email"];
            return View();
        }
        [HttpPost]
        public ActionResult ResetPassword(UserModel model)
        {
            _userService.ResetPassword(model);
            return RedirectToAction("LogIn");
        }
        [Authorize]
        // GET: AccountController/Edit/5
        public ActionResult LogOut()
        {
            if(User.Identity.IsAuthenticated)
            {
                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                var storedcookies = Request.Cookies.Keys;
                foreach (var cookie in storedcookies)
                {
                    Response.Cookies.Delete(cookie);
                }
            }
            return RedirectToAction("Index", "Home");
        }

    }
}
