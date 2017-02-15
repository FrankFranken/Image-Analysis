using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Image_Analysis.Models;
using Microsoft.AspNet.Identity;

namespace Image_Analysis.Controllers
{
    public class ImageGalleryController : Controller
    {
        private ImagesUploadEntities _context = new ImagesUploadEntities();
        // GET: ImageGallery
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Gallery()
        {
            List<ImageGallery> all = new List<ImageGallery>();
            using (ImagesUploadEntities dc = new ImagesUploadEntities())
            {            
                all = dc.ImageGalleries.ToList();
            }
            return View(all);
        }

        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(ImageGallery IG)
        {
            //Apply Validation
            if (IG.File.ContentLength > (2*1024*1024))
            {
                ModelState.AddModelError("CustomError", "File size must be less than 2 mb");
                return View();
            }
            if (!(IG.File.ContentType == "image/jpeg" || IG.File.ContentType == "image/gif"))
            {
                ModelState.AddModelError("CustomError", "File types allowed: jpeg and gif");
                return View();
            }
            IG.FileName = IG.File.FileName;
            IG.ImageSize = IG.File.ContentLength;

            byte[] data = new byte[IG.File.ContentLength];
            IG.File.InputStream.Read(data, 0, IG.File.ContentLength);
            IG.ImageData = data;
            using (ImagesUploadEntities dc = new ImagesUploadEntities())
            {
                IG.Id = User.Identity.GetUserId();
                dc.ImageGalleries.Add(IG);
                dc.SaveChanges();

            }
            
            return RedirectToAction("Gallery");
        }
    }
}