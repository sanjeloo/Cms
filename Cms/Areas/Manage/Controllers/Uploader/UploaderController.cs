using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Cms.Areas.Manage.Controllers.Uploader
{
    [Area("Manage")]
    [Consumes("multipart/form-data")]

    public class UploaderController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Image(IFormCollection  files)
        {
            if (Request.Form.Files.Count > 0)
            {
                var file = Request.Form.Files[0];

                if (file != null && file.Length > 0)
                {
                    try
                    {
                        var extension = Path.GetExtension(file.FileName);
                        var fileName = Guid.NewGuid() + extension;
                        // var path = Path.Combine( Server.MapPath("~/Images/"), fileName);
                        // file.SaveAs(path);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Images", fileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                        }
                        return Json(new
                        {
                            status = 200,
                            name = fileName,
                            message = "تصویر با موفقیت بارگزاری گردید",
                            error = 0
                        });
                    }
                    catch(Exception e)
                    {
                        return Json(new
                        {
                            status = 500,
                            name = 0,
                            message = "هنگام بارگزاری عکس خطایی رخ داد",
                            error = e.Message
                        }) ;
                    }
                   
                }
            }
            return Json(new
            {
                status = 400,
                name = 0 ,
                message = "فایلی وجود ندارد",
                error=0
            });
        }

    }
}
