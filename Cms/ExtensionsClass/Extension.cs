using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cms.ExtensionsClass
{
    //public static class Image :
    //{
    //    public async Task<IActionResult> GetData(IFormFile data)
    //    {
    //        if (Request.Form.Files.Count > 0)
    //        {
    //            var file = Request.Form.Files[0];

    //            if (file != null && file.Length > 0)
    //            {
    //                var fileName = Path.GetFileName(file.FileName);

    //                // var path = Path.Combine( Server.MapPath("~/Images/"), fileName);
    //                // file.SaveAs(path);
    //                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Images", fileName);
    //                using (var fileStream = new FileStream(filePath, FileMode.Create))
    //                {
    //                    await file.CopyToAsync(fileStream);
    //                }
    //                return StatusCode(200);
    //            }
    //        }
    //        return StatusCode(400);
    //    }
    //}
}
