using BookStore.Domain.Abstract;
using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreWebsite.Controllers
{
    public class OpinionController : Controller
    {
        private IOpinionRepository repository;
        public OpinionController(IOpinionRepository opinionRepository)
        {
            repository = opinionRepository;
        }
        // GET: Opinion
        public ActionResult Index()
        {
            return View();
        }

        // GET: Opinion/Details/5


        // POST: Opinion/Create
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

        // GET: Opinion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Opinion/Edit/5
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

        // GET: Opinion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Opinion/Delete/5
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
