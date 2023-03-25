using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iyibir.TMGD.API.Controllers
{
    public class TransportDocumentController : Controller
    {
        // GET: TransportDocument
        public ActionResult Index()
        {
            return View();
        }

        // GET: TransportDocument/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TransportDocument/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransportDocument/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TransportDocument/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TransportDocument/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TransportDocument/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TransportDocument/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
