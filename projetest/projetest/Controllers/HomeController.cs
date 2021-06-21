using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using DAL.Entities;
using BL.Repositories;
using DAL.Contexts;

namespace projetest.Controllers
{
    public class HomeController : Controller
    {

        Repository<Member> rMember;
        MyContext myContext;
        IWebHostEnvironment _environment;
        public HomeController(Repository<Member> _rMember, IWebHostEnvironment environment)
        {
            rMember = _rMember;
            _environment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet, Route("/UyeKayit")]
        public IActionResult Kayit()
        {
            return View();
        }
        [HttpPost, Route("/UyeKayit")]
        public async Task<IActionResult> KayitAsync(Member m)
        {
            rMember.Add(m);
            rMember.Save();
            ClaimsIdentity claimsIdentity = new ClaimsIdentity("Yedi");
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Sid, m.ID.ToString()));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, m.NameSurName));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Email, m.Mail));
            Member girenuye = rMember.GetBy(f => f.ID == m.ID);

            claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, "uye")); //Enum.GetName(typeof(ERole), ERole.uye))
           
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal();
            claimsPrincipal.AddIdentity(claimsIdentity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsPrincipal), new AuthenticationProperties() { IsPersistent = true });

            return RedirectToAction("Index", "Home", new { area = "uye" });
        }

        [Route("/giris")]
        public IActionResult Giris()
        {
            return View();
        }
        static Member girisyapan;
        [HttpPost, Route("/giris")]
        public async Task<IActionResult> Giris(Member member)
        {
           
            //if (!string.IsNullOrEmpty(ReturnUrl) && ReturnUrl.Contains("uye"))

            Member uye = rMember.GetBy(f => f.Mail == member.Mail && f.Password == member.Password) ?? null;
            if (member.Mail == null || member.Password == null)
            {
                ViewBag.Hata = "Kullanıcı Adı veya Şifre Boş Geçilemez";
                return View();
            }
            else if (uye != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, uye.Mail),
                    new Claim(ClaimTypes.Name, uye.NameSurName),
                    new Claim(ClaimTypes.Sid, uye.ID.ToString())
                };
                var useridentity = new ClaimsIdentity(claims, "Home");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Home", new { area = "uye" });
                /*
                ClaimsIdentity claimsIdentity = new ClaimsIdentity("projetest.WebuUI");
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Sid, uye.ID.ToString()));
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, uye.NameSurName));
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Email, uye.Mail));
                Member girenuye = rMember.GetBy(f => f.ID == uye.ID);
                //uyemail = member.Mail;
                girisyapan = rMember.GetBy(x => x.Mail == member.Mail);

                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, "uye")); //Enum.GetName(typeof(ERole), ERole.uye))
                                                                                                                 //claimsIdentity.AddClaim(new Claim(ClaimTypes.Role,"admin"));
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal();
                claimsPrincipal.AddIdentity(claimsIdentity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsPrincipal), new AuthenticationProperties() { IsPersistent = true });
                return RedirectToAction("Index", "Home", new { area = "uye" } );
            */

            }
            else
            {
                ViewBag.Hata = "Kullanıcı adı veya Şifre Hatalı";
                return View();
            }
        }

        public async Task<IActionResult> Cikis()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
        public async Task<IActionResult> AccessDenied()
        {
            if (HttpContext.User.Identity.IsAuthenticated) await HttpContext.SignOutAsync();
            return Redirect("/giris");
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
            string uyeid = User.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Sid).Value;
            return View(rMember.GetBy(r => r.ID.ToString() == uyeid));
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
