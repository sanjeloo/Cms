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
        public IActionResult List()
        {
            return View();
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
