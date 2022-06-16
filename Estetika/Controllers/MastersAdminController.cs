﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Estetika.Models.Entities;

namespace Estetika.Controllers
{
    public class MastersAdminController : Controller
    {
        private SalonEntities db = new SalonEntities();

        // GET: MastersAdmin
        public ActionResult Index()
        {
            var master = db.Master.Include(m => m.Tip_Master);
            return View(master.ToList());
        }

        // GET: MastersAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Master master = db.Master.Find(id);
            if (master == null)
            {
                return HttpNotFound();
            }
            return View(master);
        }

        // GET: MastersAdmin/Create
        public ActionResult Create()
        {
            ViewBag.ID_Tip_Master = new SelectList(db.Tip_Master, "ID_Tip_Master", "Imya_Tip_Master");
            return View();
        }

        // POST: MastersAdmin/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Master,Imya_Master,Opisanie_Master,Photo,Opit,ID_Tip_Master")] Master master, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            {
                if (uploadImage != null)
                {
                    byte[] imageData = null;
                    using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                    }
                    master.Photo = imageData;
                }
                db.Master.Add(master);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Tip_Master = new SelectList(db.Tip_Master, "ID_Tip_Master", "Imya_Tip_Master", master.ID_Tip_Master);
            return View(master);
        }

        // GET: MastersAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Master master = db.Master.Find(id);
            if (master == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Tip_Master = new SelectList(db.Tip_Master, "ID_Tip_Master", "Imya_Tip_Master", master.ID_Tip_Master);
            return View(master);
        }

        // POST: MastersAdmin/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Master,Imya_Master,Opisanie_Master,Photo,Opit,ID_Tip_Master")] Master master)
        {
            if (ModelState.IsValid)
            {
                db.Entry(master).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Tip_Master = new SelectList(db.Tip_Master, "ID_Tip_Master", "Imya_Tip_Master", master.ID_Tip_Master);
            return View(master);
        }

        // GET: MastersAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Master master = db.Master.Find(id);
            if (master == null)
            {
                return HttpNotFound();
            }
            return View(master);
        }

        // POST: MastersAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Master master = db.Master.Find(id);
            db.Master.Remove(master);
            db.SaveChanges();
            return RedirectToAction("Index");
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
