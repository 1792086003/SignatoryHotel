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
using PagedList;
using Lanxess.CN.SignatoryHotel.WebUI.Classes;
using Newtonsoft.Json;

namespace Lanxess.CN.SignatoryHotel.WebUI.Controllers
{
    /// <summary>
    /// 酒店控制器
    /// </summary>
    [lanxessSSOAuthFilterAttribute]
    [lanxessLanguageFilterAttribute]
    public class HotelsController : Controller
    {
        //获得实体访问上下文
        private SignatoryHotelContext db = new SignatoryHotelContext();
        //指定分页记录阀值
        private const int PageSize = 10;
        // GET: Hotels
        public ActionResult Index(int? page,string sortOrder,string currentFilter,string ProvinceID,string CityID,string searchString)
        {
            //searchString保留搜索值
            if (searchString != null)
            {
                page = 1;
            }else
            {
                searchString = currentFilter;
            }
            //保留用户名
            //ViewBag.UserName = User.Identity.Name;
            ViewBag.UserName = Session["SignatoryHotelCWID"];
            //保留排序字段
            ViewBag.currentSort = sortOrder;
            //保留切换排序方式
            ViewBag.sortByHotelName = string.IsNullOrEmpty(sortOrder) ? "hotelName_desc":"";
            ViewBag.sortByHotelCNName = sortOrder == "hotelCNName" ? "hotelCNName_desc" : "hotelCNName";
            ViewBag.sortByStar = sortOrder == "star" ? "star_desc" : "star";
            //获得保留的搜索值
            ViewBag.currentFilter = searchString;
            
            //指定当前页索引
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            //获得所有酒店列表
            var hotels = db.Hotels.Include(h => h.City).Include(h => h.Province).ToList();
            //所有省市列表填充dropdownlist
            //ViewBag.CityID = new SelectList(db.Cities,"CityID","CityName");
            ViewBag.ProvinceID = new SelectList(db.Provinces, "ProvinceID", "ProvinceName");
            //ViewData["Province"]= new SelectList(db.Provinces, "ProvinceID", "ProvinceName"); 
            //ViewData["City"]= new SelectList(db.Cities, "CityID", "CityName");
            //根据省份dropdownlist值过滤列表
            if (!string.IsNullOrEmpty(ProvinceID))
            {
                hotels = hotels.Where(h => h.ProvinceID == int.Parse(ProvinceID)).ToList();
                ViewBag.Province = ProvinceID;
                int intProvince = int.Parse(ProvinceID);
                ViewBag.CityID = new SelectList(db.Cities.Where(c=>c.ProvinceID==intProvince), "CityID", "CityName");
            }
            else
            {
                ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityName");
            }
            //根据城市dropdownlist值过滤列表
            if (!string.IsNullOrEmpty(CityID))
            {
                hotels = hotels.Where(h=>h.CityID==int.Parse(CityID)).ToList();
                //保留城市ID
                ViewBag.City = CityID;
            }
            //根据保留的搜索值过滤列表
            if (!string.IsNullOrEmpty(searchString))
            {
                hotels = hotels.Where(h => h.Name.Contains(searchString)||h.CNName.Contains(searchString)).ToList();
            }
            //列表排序方式切换
            switch (sortOrder)
            {
                case "hotelName_desc":
                    hotels = hotels.OrderByDescending(h=>h.Name).ToList();
                    break;
                case "hotelCNName_desc":
                    hotels = hotels.OrderByDescending(h => h.CNName).ToList();
                    break;
                case "hotelCNName":
                    hotels = hotels.OrderBy(h => h.CNName).ToList();
                    break;
                case "star_desc":
                    hotels = hotels.OrderByDescending(h => h.Star).ToList();
                    break;
                case "star":
                    hotels = hotels.OrderBy(h => h.Star).ToList();
                    break;
                default:
                    hotels = hotels.OrderBy(h => h.ProvinceID).ToList();
                    break;
            }
            //返回分页的列表
            return View(hotels.ToPagedList(pageIndex,PageSize));
        }

        // GET: Hotels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel hotel = db.Hotels.Find(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View(hotel);
        }

        // GET: Hotels/Create
        //[Authorize]
        public ActionResult Create()
        {
            //传递新加酒店所属的省份
            ViewBag.CityID = new List<SelectListItem>(); 
            ViewBag.ProvinceID = new SelectList(db.Provinces, "ProvinceID", "ProvinceName");
            return View();
        }

        // POST: Hotels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HotelID,Name,CNName,Star,Address,AddressCN,CityID,ProvinceID,Zip,Telephone1,Telephone2,Fax1,Fax2,Email")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                db.Hotels.Add(hotel);
                db.SaveChanges();
                switch (Session["SignatoryHotelLanguage"].ToString().ToUpper())
                {
                    case "ZH-CN":
                        return RedirectToAction("Success", new { hotelName = hotel.CNName, actionName = Resources.Resource.Create, CityID = Request.QueryString["CityID"], currentFilter = Request.QueryString["currentFilter"] });
                        break;
                    default:
                        return RedirectToAction("Success", new { hotelName = hotel.Name, actionName = Resources.Resource.Create, CityID = Request.QueryString["CityID"], currentFilter = Request.QueryString["currentFilter"] });
                        break;
                }
                
            }
            //传递新加酒店所属省份城市
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityName", hotel.CityID);
            ViewBag.ProvinceID = new SelectList(db.Provinces, "ProvinceID", "ProvinceName", hotel.ProvinceID);
            
            return View(hotel);
        }

        // GET: Hotels/Edit/5
        //[Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel hotel = db.Hotels.Find(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            //传递所编酒店所属省份城市
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityName", hotel.CityID);
            ViewBag.ProvinceID = new SelectList(db.Provinces, "ProvinceID", "ProvinceName", hotel.ProvinceID);
            return View(hotel);
        }

        // POST: Hotels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HotelID,Name,CNName,Star,Address,AddressCN,CityID,ProvinceID,Zip,Telephone1,Telephone2,Fax1,Fax2,Email")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotel).State = EntityState.Modified;
                db.SaveChanges();
                
                switch(Session["SignatoryHotelLanguage"].ToString().ToUpper())
                {
                    case "ZH-CN":
                        return RedirectToAction("Success", new { hotelName = hotel.CNName, actionName = Resources.Resource.Edit, CityID = Request.QueryString["CityID"], currentFilter = Request.QueryString["currentFilter"] });
                        break;
                    default:
                        return RedirectToAction("Success", new { hotelName = hotel.Name, actionName = Resources.Resource.Edit, CityID = Request.QueryString["CityID"], currentFilter = Request.QueryString["currentFilter"] });
                        break;
                }  
            }
            //传递所编酒店所属省份城市
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityName", hotel.CityID);
            ViewBag.ProvinceID = new SelectList(db.Provinces, "ProvinceID", "ProvinceName", hotel.ProvinceID);
            return View(hotel);
        }

        // GET: Hotels/Delete/5
        //[Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel hotel = db.Hotels.Find(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View(hotel);
        }

        // POST: Hotels/Delete/5
        //[Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hotel hotel = db.Hotels.Find(id);
            db.Hotels.Remove(hotel);
            db.SaveChanges();
            switch (Session["SignatoryHotelLanguage"].ToString().ToUpper())
            {
                case "ZH-CN":
                    return RedirectToAction("Success", new { hotelName = hotel.CNName, actionName = Resources.Resource.Delete, CityID = Request.QueryString["CityID"], currentFilter = Request.QueryString["currentFilter"] });
                    break;
                default:
                    return RedirectToAction("Success", new { hotelName = hotel.Name, actionName = Resources.Resource.Delete, CityID = Request.QueryString["CityID"], currentFilter = Request.QueryString["currentFilter"] });
                    break;
            }
            
        }

        public ActionResult Success()
        {
            return View();
        }
        //获得某省内的城市，返回异步刷新所需数据
        public ActionResult GetCities(int ProvinceID)
        {
            List<City> items = db.Cities.Where(c => c.ProvinceID == ProvinceID).ToList();
            var data = items.Select(d => new {CityID=d.CityID,CityName=d.CityName});
            if (Request.IsAjaxRequest())
            {
                return Json(data,JsonRequestBehavior.AllowGet);
            }
            else
            {
                return View();
            }
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
