using Microsoft.AspNetCore.Mvc;
using RSS.Business.Interfaces;
using RSS.Business.Models;
using RSS.WebApp.Models;
using System.Diagnostics;

namespace RSS.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        const string SessionId = "_Id";
        public HomeController(ILogger<HomeController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }
        public IActionResult Index()
        {
            var userid = HttpContext.Session.GetInt32(SessionId);
            if (userid != null)
            {
                UserModel user = _userService.GetAllUsers().Where(x => x.Id == userid).FirstOrDefault();
                return View(user);
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}