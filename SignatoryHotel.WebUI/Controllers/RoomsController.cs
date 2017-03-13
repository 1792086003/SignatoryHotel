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
    /// 酒店房间控制器
    /// </summary>
    [lanxessSSOAuthFilterAttribute]
    [lanxessLanguageFilterAttribute]
    public class RoomsController : Controller
    {
        //获得实体访问上下文
        private SignatoryHotelContext db = new SignatoryHotelContext();

        // GET: Rooms
        public ActionResult Index(int? HotelID,string sortOrder)
        {
            //保留切换排序方式
            ViewBag.sortByPrice= string.IsNullOrEmpty(sortOrder) ? "price_desc" : "";
            //根据酒店获得其有房间列表
            var rooms = db.Rooms.Include(r => r.Hotel);
            rooms = rooms.Where(r => r.HotelID == HotelID);
            //列表排序方式切换
            switch (sortOrder)
            {
                case "price_desc":
                    rooms = rooms.OrderByDescending(r => r.Price);
                    break;
                default:
                    rooms = rooms.OrderBy(r => r.Price);
                    break;
            }
            return View(rooms.ToList());
        }

        // GET: Rooms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // GET: Rooms/Create
        //[Authorize]
        public ActionResult Create(int? HotelID)
        {
            //传递新加房间所属的酒店            
            ViewBag.Hotels = new SelectList(db.Hotels.Where(h=>h.HotelID==HotelID), "HotelID", "Name");
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoomID,Classification,Price,Remark,HotelID")] Room room)
        {
            if (ModelState.IsValid)
            {
                db.Rooms.Add(room);
                db.SaveChanges();
                return RedirectToAction("Success", new { HotelID = room.HotelID, actionName = Resources.Resource.Create, roomClassification = room.Classification });
            }
            //传递新加房间所属酒店
            //ViewBag.Hotels = new SelectList(db.Hotels, "HotelID", "Name", room.HotelID);
            return View(room);
        }

        // GET: Rooms/Edit/5
        //[Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            //传递所编房间所属酒店
            ViewBag.HotelID = new SelectList(db.Hotels, "HotelID", "Name", room.HotelID);
            return View(room);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoomID,Classification,Price,Remark,HotelID")] Room room)
        {
            if (ModelState.IsValid)
            {
                db.Entry(room).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Success", new { HotelID = room.HotelID, actionName = Resources.Resource.Edit, roomClassification = room.Classification });
            }
            //传递所编房间所属酒店
            ViewBag.HotelID = new SelectList(db.Hotels, "HotelID", "Name", room.HotelID);
            return View(room);
        }

        // GET: Rooms/Delete/5
        //[Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // POST: Rooms/Delete/5
        //[Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Room room = db.Rooms.Find(id);
            db.Rooms.Remove(room);
            db.SaveChanges();
            return RedirectToAction("Success", new { HotelID = room.HotelID, actionName = Resources.Resource.Delete, roomClassification = room.Classification });
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
