using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fresher;
using System.Globalization;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace FreshersManagement.MVC.Areas.Fresher.Controllers
{
    public class FresherController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44394/api");
        HttpClient client;

        public FresherController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        public ActionResult Index()
        {
            List<FresherDetail> fresherList = new List<FresherDetail>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress+ "/values").Result;
            if(response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                fresherList = JsonConvert.DeserializeObject<List<FresherDetail>>(data); 
            }

            return View(fresherList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FresherDetail fresher)
        {

            string data = JsonConvert.SerializeObject(fresher);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/values", content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public JsonResult Edit(int id)
        {
            var fresher = new FresherDetail();

            List<FresherDetail> fresherList = new List<FresherDetail>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/values").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                fresherList = JsonConvert.DeserializeObject<List<FresherDetail>>(data);
            }

            foreach (var item in fresherList)
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
        [ValidateAntiForgeryToken()]
        public ActionResult Edit(FresherDetail fresher)
        {
            string data = JsonConvert.SerializeObject(fresher);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(client.BaseAddress + "/values/" + fresher.id, content).Result;

            if (response.IsSuccessStatusCode)
            {
                return Json(JsonRequestBehavior.AllowGet);
            }

            return View();
        }
        
        public ActionResult DeleteFresher(int id)
        {
            FresherDetail fresher = null;
            List<FresherDetail> fresherList = new List<FresherDetail>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/values").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                fresherList = JsonConvert.DeserializeObject<List<FresherDetail>>(data);
            }
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
        public ActionResult DeleteFresher(int id, string none)
        {
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/values/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            } 
            return RedirectToAction("Index");
        }
    }
}