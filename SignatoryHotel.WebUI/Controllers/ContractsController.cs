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
    /// 酒店合同控制器
    /// </summary>
    [lanxessSSOAuthFilterAttribute]
    [lanxessLanguageFilterAttribute]
    public class ContractsController : Controller
    {
        //获得实体访问上下文
        private SignatoryHotelContext db = new SignatoryHotelContext();

        // GET: Contracts
        public ActionResult Index(int? HotelID)
        {
            var contracts = db.Contracts.Include(c => c.Hotel);
            contracts = contracts.Where(c=>c.HotelID==HotelID);
            return View(contracts.ToList());
        }

        // GET: Contracts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = db.Contracts.Find(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            return View(contract);
        }

        // GET: Contracts/Create
        //[Authorize]
        public ActionResult Create(int? HotelID)
        {
            //传递新加合同所属的酒店
            ViewBag.Hotels = new SelectList(db.Hotels.Where(h=>h.HotelID==HotelID), "HotelID", "Name");
            return View();
        }

        // POST: Contracts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContractID,Contacter,Telephone,Mobile,Email,Start,End,HotelID")] Contract contract)
        {
            if (ModelState.IsValid)
            {
                db.Contracts.Add(contract);
                db.SaveChanges();
                return RedirectToAction("Success", new { HotelID = contract.HotelID, actionName = Resources.Resource.Create, contractStart=contract.Start });
            }
            //传递新加合同所属的酒店
            //ViewBag.HotelID = new SelectList(db.Hotels, "HotelID", "Name", contract.HotelID);
            return View(contract);
        }

        // GET: Contracts/Edit/5
        //[Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = db.Contracts.Find(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            //传递所编合同所属酒店
            ViewBag.HotelID = new SelectList(db.Hotels, "HotelID", "Name", contract.HotelID);
            return View(contract);
        }

        // POST: Contracts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContractID,Contacter,Telephone,Mobile,Email,Start,End,HotelID")] Contract contract)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contract).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Success", new { HotelID = contract.HotelID, actionName = Resources.Resource.Edit, contractStart = contract.Start });
            }
            //传递所编合同所属酒店
            ViewBag.HotelID = new SelectList(db.Hotels, "HotelID", "Name", contract.HotelID);
            return View(contract);
        }

        // GET: Contracts/Delete/5
        //[Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = db.Contracts.Find(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            return View(contract);
        }

        // POST: Contracts/Delete/5
        //[Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contract contract = db.Contracts.Find(id);
            db.Contracts.Remove(contract);
            db.SaveChanges();
            return RedirectToAction("Success", new { HotelID = contract.HotelID, actionName = Resources.Resource.Delete, contractStart = contract.Start });
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
