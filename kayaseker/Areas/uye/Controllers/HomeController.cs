using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace kayaseker.WebUI.Areas.uye.Controllers
{
    [Area("uye"), Authorize(Roles = "uye")]
    public class HomeController : Controller
    {
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
