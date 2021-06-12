using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace projetest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Test()
        {
            return View();
        }

        public IActionResult unity()
        {
            return View();
        }
        public IActionResult mekan()
        {
            return View();
        }

        public IActionResult Profil()
        {
            return View();
        }
        
        public IActionResult harita()
        {
            return View();
        }
        
        public IActionResult Yapiliyor()
        {
            return View();
        }
        public IActionResult istanbul()
        {
            return View();
        }
        
        public IActionResult rehber()
        {
            return View();
        }
        public IActionResult basarim()
        {
            return View();
        }
        public IActionResult odul()
        {
            return View();
        }
        public IActionResult Sohbet()
        {
            return View();
        }

        public IActionResult Ayasofya()
        {
            return View();
        }

        public IActionResult Yapilar()
        {
            return View();
        }
        public IActionResult UploadPicture()
        {
          
            foreach (var file in Request.Form.Files)
            {
                string ImageTitle = file.FileName;
                var yeniresimad = Guid.NewGuid() + ImageTitle.Replace(" ", "_");
                var yuklenecekyer = Path.Combine(Directory.GetCurrentDirectory(),
                            "wwwroot/medya/" + yeniresimad);
                var stream = new FileStream(yuklenecekyer, FileMode. Create);
                file.CopyTo(stream);
                
            }
            return RedirectToAction("Test");
        }
    }
}
