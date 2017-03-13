using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lanxess.CN.SignatoryHotel.BussinessEntity;
using Lanxess.CN.SignatoryHotel.BussinessEntity.DataAccess;
using Lanxess.CN.SignatoryHotel.WebUI.Classes;

namespace Lanxess.CN.SignatoryHotel.WebUI.Controllers
{
    /// <summary>
    /// 城市控制器
    /// </summary>
    [lanxessSSOAuthFilterAttribute]
    [lanxessLanguageFilterAttribute]
    public class CitiesController : Controller
    {
        //获得实体访问上下文
        private SignatoryHotelContext db = new SignatoryHotelContext();

        // GET: Cities
        public ActionResult Index(string ProvinceID)
        {
            var cities = db.Cities.Include(c => c.Province).ToList();
            if (!string.IsNullOrEmpty(ProvinceID))
            {
                cities = cities.Where(c => c.ProvinceID == int.Parse(ProvinceID)).ToList();
                ViewBag.Province = ProvinceID;
            }
            ViewBag.ProvinceID = new SelectList(db.Provinces, "ProvinceID", "ProvinceName");                        
            return View(cities);
        }

        // GET: Cities/Details/5
        //获得特定城市详细信息
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = db.Cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        // GET: Cities/Create
        public ActionResult Create()
        {
            //可选城市所属省份列表
            ViewBag.ProvinceID = new SelectList(db.Provinces, "ProvinceID", "ProvinceName");
            return View();
        }

        // POST: Cities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CityID,CityName,ProvinceID")] City city)
        {
            if (ModelState.IsValid)
            {
                db.Cities.Add(city);
                db.SaveChanges();
                return RedirectToAction("Success", new { cityName = city.CityName, actionName = Resources.Resource.Create });
            }
            //传递新加城市所属省份，返回该省份城市列表
            ViewBag.ProvinceID = new SelectList(db.Provinces, "ProvinceID", "ProvinceName", city.ProvinceID);
            return View(city);
        }

        // GET: Cities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = db.Cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            //传递编辑城市所属省份，返回该省份城市列表
            ViewBag.ProvinceID = new SelectList(db.Provinces, "ProvinceID", "ProvinceName", city.ProvinceID);
            return View(city);
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CityID,CityName,ProvinceID")] City city)
        {
            if (ModelState.IsValid)
            {
                db.Entry(city).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Success", new { cityName = city.CityName, actionName = Resources.Resource.Edit });
            }
            //传递编辑城市所属省份，返回该省份城市列表
            ViewBag.ProvinceID = new SelectList(db.Provinces, "ProvinceID", "ProvinceName", city.ProvinceID);
            return View(city);
        }

        // GET: Cities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = db.Cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            City city = db.Cities.Find(id);
            db.Cities.Remove(city);
            db.SaveChanges();
            return RedirectToAction("Success", new { cityName = city.CityName, actionName = Resources.Resource.Delete });
        }

        public ActionResult Success()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
