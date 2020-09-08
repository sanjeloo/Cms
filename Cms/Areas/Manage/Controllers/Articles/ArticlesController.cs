using DAL;
using Entities.Entities.Articles;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cms.Areas.Manage.Controllers.Articles
{
    [Area("Manage")]
    public class ArticlesController: Controller
    {
        private readonly ApplicationContext db;

        public ArticlesController(ApplicationContext db)
        {
            this.db = db;
        }
        public IActionResult List()
        {
           
            return View(db.Articles.OrderByDescending(c=>c.Id).Where(c=>c.IsDelete != true).ToList());
        } 
        public IActionResult Update()
        {
            return View();
        } 
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert( Article model)
        {
            return View();
        } 
        public IActionResult Delete()
        {
            return View();
        }

    }
}
