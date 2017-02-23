using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Image_Analysis.Models;
using Image_Analysis.ViewModels;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Image = System.Drawing.Image;

namespace Image_Analysis.Controllers
{
    [Authorize]
    public class ImageGalleryController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        // GET: ImageGallery
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Gallery()
        {
            
            List<ImageGallery> all = new List<ImageGallery>();
            all.Clear();
            using (ImagesUploadEntities dc = new ImagesUploadEntities())
            {
                if (dc.ImageGalleries != null)
                {
                    var ID = User.Identity.GetUserId();
                    foreach (var image in dc.ImageGalleries)
                    {
                        if (image.Id == ID && image.Id != null)
                        {
                            all.Add(image);                    
                        }
                    }
                }
                return View(all);
            }      
        }
        public ActionResult Analize(int id)
        {
            AnalizeViewModel viewModel = new AnalizeViewModel();
            using (ImagesUploadEntities dc = new ImagesUploadEntities())
            {
                if (dc.ImageGalleries != null)
                {
                    foreach (var image in dc.ImageGalleries)
                    {
                        if (image.ImageID == id)
                        {
                            viewModel.Image = Convert.ToBase64String(image.ImageData);
                        }
                    }
                }
            }
            return View(viewModel);
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