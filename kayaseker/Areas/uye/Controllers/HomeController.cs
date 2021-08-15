using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using kayaseker_BL.Repositories;
using kayaseker.DAL.Entities;
using Microsoft.AspNetCore.Hosting;
using kayaseker.DAL.Contexts;

namespace kayaseker.WebUI.Areas.uye.Controllers
{
    [Area("uye"), Authorize(Roles = "uye")]
    public class HomeController : Controller
    {
        Repository<Member> rMember;
        Repository<MediaPicture> rMediaPicture;
        MyContext myContext;
        IWebHostEnvironment _environment;
        public HomeController(Repository<Member> _rMember, Repository<MediaPicture> _rMediaPicture, IWebHostEnvironment environment)
        {
            rMember = _rMember;
            rMediaPicture = _rMediaPicture;
            _environment = environment;
        }
        public IActionResult Index()
        {
            DateTime ilk = new DateTime(2019, 05, 20, 22, 32, 00);
            TimeSpan gecenGun = DateTime.Now - ilk;
            ViewBag.gun = Math.Round(gecenGun.TotalDays);
            ViewBag.saat = Math.Round(gecenGun.TotalHours);
            ViewBag.dakika = Math.Round(gecenGun.TotalMinutes);
            ViewBag.saniye = Math.Round(gecenGun.TotalSeconds);
            return View();
        }
        public IActionResult Istanbul()
        {
            List<MediaPicture> mediaPictures = rMediaPicture.GetAll().ToList();
            return View(mediaPictures);
        }
        [HttpGet]
        public IActionResult UploadPicture()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UploadPicture(MediaPicture mediaPicture)
        {
            MediaPicture picture = new MediaPicture();
            foreach (var file in Request.Form.Files)
            {
                picture.Title = mediaPicture.Title;
                string ImageTitle = file.FileName;
                picture.Name = ImageTitle;
                var yeniresimad = Guid.NewGuid() + ImageTitle.Replace(" ", "_");
                var yuklenecekyer = Path.Combine(Directory.GetCurrentDirectory(),
                            "wwwroot/medya/" + yeniresimad);
                var stream = new FileStream(yuklenecekyer, FileMode.Create);
                file.CopyTo(stream);
                picture.ImageData = yeniresimad;
            }
            picture.Owner = mediaPicture.Owner;
            picture.Description = mediaPicture.Description;
            picture.Like = 0;
            picture.View = 0;
            picture.LogDate = DateTime.Now;
            picture.contentID = mediaPicture.contentID;
            picture.Contents.ID = 2;
            return RedirectToAction("Istanbul");
        }
        public IActionResult Profil()
        {
            return View();
        }

        public async Task<IActionResult> Cikis()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
