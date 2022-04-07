using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FreshersManagement.Service;
using Fresher;
using System.Globalization;

namespace FreshersManagement.MVC.Areas.Fresher.Controllers
{
    public class FresherController : Controller
    {
        private readonly IService service = new FresherService();

        public ActionResult Index()
        {
            return View(service.GetAllFreshers());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FresherDetail fresher)
        {
            if (ModelState.IsValid)
            {
                service.SaveFresher(fresher);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public JsonResult Edit(int id)
        {
            var fresher = new FresherDetail();
            
            foreach (var item in service.GetAllFreshers())
            {
                if (item.id == id)
                {
                    fresher = item;
                }
            }
            DateTime dateTime = DateTime.Parse(fresher.dateOfBirth);
            fresher.dateOfBirth = dateTime.ToString("yyyy-MM-dd");
            
            return Json(fresher, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Edit(FresherDetail fresher)
        {
            int affectRows = 0;
            if (ModelState.IsValid)
            {
                affectRows = service.SaveFresher(fresher);
            }
            return Json(affectRows, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult Delete(int id)
        {
            FresherDetail fresher = null;
            List<FresherDetail> fresherList = service.GetAllFreshers().ToList();
            foreach (var item in fresherList)
            {
                if (item.id == id)
                {
                    fresher = item;
                }
            }

            return View(fresher);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection formCollection)
        {
            service.DeleteFresher(id);

            return RedirectToAction("Index");
        }
    }
}