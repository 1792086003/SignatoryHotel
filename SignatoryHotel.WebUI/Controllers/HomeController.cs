using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lanxess.CN.SignatoryHotel.BussinessEntity;
using Lanxess.CN.SignatoryHotel.BussinessEntity.DataAccess;
using System.Data;
using System.Data.Entity;

namespace SignatoryHotel.WebUI.Controllers
{
    
    public class HomeController : Controller
    {
        private SignatoryHotelContext db = new SignatoryHotelContext();
        public ActionResult GetCities(int ProvinceID)
        {
            List<City> items = db.Cities.Where(c => c.ProvinceID == ProvinceID).ToList();
            if (Request.IsAjaxRequest())
            {
                return Json(items, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(null);
            }
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}