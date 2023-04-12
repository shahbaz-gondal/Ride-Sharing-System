using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RSS.Business.DataServices;
using RSS.Business.Interfaces;
using RSS.Business.Models;
using System.Xml.Linq;

namespace RSS.WebApp.Controllers
{
    public class RequestController : Controller
    {
        private readonly IRequestService _requestService;
        private readonly IUserService _userService;
        const string SessionId = "_Id";
        public RequestController(IRequestService requestService, IUserService userService)
        {
            _requestService = requestService;
            _userService = userService;
        }
        // GET: RequestController
        public ActionResult GetAllRequests(string? fromCity, string? toCity)
        {
            if (fromCity == null || toCity == null)
            {
                return View(_requestService.GetAll());
            }
            else
            {
                return View(_requestService.SearchRequest(fromCity, toCity));
            }
        }

        [Authorize]
        public ActionResult GetmyRequests()
        {
            int? id = HttpContext.Session.GetInt32(SessionId);
            if (id == null)
            {
                return RedirectToAction("LogOut", "Account");
            }
            return View(_requestService.myRequests((int)id));
        }

        [Authorize]
        // GET: RequestController/Create
        public ActionResult Create()
        {
            ViewData["Id"] = (int)HttpContext.Session.GetInt32(SessionId);
            return View();
        }
        // POST: RequestController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(RequestModel model)
        {
            try
            {
                _requestService.Add(model);
                return RedirectToAction("GetmyRequests");
            }
            catch
            {
                return View();
            }
        }

        [Authorize]
        // GET: RequestController/Edit/5
        public ActionResult Edit(int id)
        {
            var request = _requestService.GetAll().Where(x => x.Id == id).FirstOrDefault();
            ViewData["Id"] = (int)HttpContext.Session.GetInt32(SessionId);
            return View(request);
        }

        // POST: RequestController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(RequestModel model)
        {
            try
            {
                _requestService.Update(model);
                return RedirectToAction("GetmyRequests");
            }
            catch
            {
                return View();
            }
        }

        [Authorize]
        // GET: RequestController/Delete/5
        public ActionResult Delete(int id)
        {
            _requestService.Delete(id);
            return RedirectToAction("GetmyRequests");
        }
        [Authorize]
        public ActionResult Details(int id)
        {
            var Details = _requestService.GetAll().Where(x => x.Id == id).FirstOrDefault();
            var driver = _userService.GetAllUsers().Where(x=>x.Id == Details.UserId).FirstOrDefault();

            dynamic model = new System.Dynamic.ExpandoObject();
            model.dt = Details;
            model.dr = driver;

            return View(model);
        }
    }
}
