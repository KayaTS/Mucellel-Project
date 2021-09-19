using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using kayaseker.DAL.Entities;
using kayaseker_BL.Repositories;
using kayaseker.DAL.Contexts;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using kayaseker.WebUI.ViewModels;

namespace kayaseker.Controllers
{
    public class HomeController : Controller
    {

        Repository<Member> rMember;
        Repository<MediaPicture> rMediaPicture;
<<<<<<< HEAD
        Repository<ImageComments> rImageComment;
=======

>>>>>>> c9961113a2e299b14b18342be8e93190b2e1f8fa
        MyContext myContext;

        IWebHostEnvironment _environment;
<<<<<<< HEAD
        public HomeController(Repository<Member> _rMember, Repository<ImageComments> _rImageComment, Repository<MediaPicture> _rMediaPicture, IWebHostEnvironment environment)
        {
            rMember = _rMember;
            rMediaPicture = _rMediaPicture;
            rImageComment = _rImageComment;
=======
        public HomeController(Repository<Member> _rMember, Repository<MediaPicture> _rMediaPicture, IWebHostEnvironment environment)
        {
            rMember = _rMember;
            rMediaPicture = _rMediaPicture;
>>>>>>> c9961113a2e299b14b18342be8e93190b2e1f8fa
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
        public IActionResult Login(string ReturnUrl)
        {
            // Login sayfası
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }
        [HttpPost, Route("/giris")]
        public async Task<IActionResult> Login(string ReturnUrl, int a, string password, string mail)
        {
            /*if (!string.IsNullOrEmpty(ReturnUrl) && ReturnUrl.Contains("panel"))
            {
                Admin admin = rAdmin.GetBy(a => a.Mail == member.Mail && a.Password == member.Password) ?? null;
                                 
                if (admin != null)
                {
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity("adminIdentity");
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, admin.Mail));
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, Enum.GetName(typeof(ERole), ERole.admin)));
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal();
                    claimsPrincipal.AddIdentity(claimsIdentity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsPrincipal), new AuthenticationProperties() { IsPersistent = true });
                    return RedirectToAction("Index", "Home", new { area = "panel" });
                }
                else
                {
                    ViewBag.Hata = "Admin adı veya Şifre Hatalı";
                    return View();
                }

            }
            else */

            if (string.IsNullOrEmpty(ReturnUrl))
            {
                Member uye = new Member();
                uye = rMember.GetBy(a => a.Mail == mail && a.Password == password);
                
                if (uye != null)
                {
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity("Yedi");
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Sid, uye.ID.ToString()));
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, uye.NameSurName));
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Email, uye.Mail));
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, "uye")); //Enum.GetName(typeof(ERole), ERole.uye))
                                                                                //claimsIdentity.AddClaim(new Claim(ClaimTypes.Role,"admin"));

                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal();
                    claimsPrincipal.AddIdentity(claimsIdentity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsPrincipal), new AuthenticationProperties() { IsPersistent = true });
                    return RedirectToAction("Index", "Home", new { area = "uye" });
                }
                else
                {
                    ViewBag.Hata = "Kullanıcı adı veya Şifre Hatalı";
                    return View();
                }
            }
           
            ViewBag.Hata = "Kullanıcı adı veya Şifre Hatalı";
            return View();
        }
        public async Task<IActionResult> Cikis()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        public IActionResult Mekan()
        {
            return View();
        }
        public IActionResult Milyon()
        {
            return View();
        }
        public IActionResult Topkapi()
        {
            return View();
        }

        public IActionResult UyeProfil(int id)
        {
            MemberPictureVM memberPictureVM = new MemberPictureVM()
            {
                Member = rMember.GetBy(r => r.ID == id),
                MediaPictures = rMediaPicture.GetAll(x => x.contentID == id).ToList()
            };
            return View(memberPictureVM);
        }

        public IActionResult Harita()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Istanbul()
        {
<<<<<<< HEAD
           List<MediaPicture> mediaPictures = rMediaPicture.GetAll().ToList();
           return View(mediaPictures);
           
=======
            List<MediaPicture> mediaPictures = rMediaPicture.GetAll().ToList();
            return View(mediaPictures);
>>>>>>> c9961113a2e299b14b18342be8e93190b2e1f8fa
        }
        [HttpGet]
        public IActionResult Istanbul2()
        {
            List<MediaPicture> mediaPictures = rMediaPicture.GetAll().ToList();
            return View(mediaPictures);

        }

        public IActionResult Resim(int id)
        {
            MediaPicture mediaPicture = rMediaPicture.GetBy(x => x.ID == id);
            MemberPictureVM memberPictureVM = new MemberPictureVM()
            {
                Member = rMember.GetBy(r => r.ID == id),
                MediaPicture = rMediaPicture.GetBy(x => x.ID == id)
            };
            return View(memberPictureVM);
        }
        [HttpPost]
        public IActionResult Resim(ImageComments comment)
        {
            comment.MemberID = Convert.ToInt32(User.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Sid).Value);
            //  comment.Member = rMember.GetBy(x => x.ID == comment.MemberID);
            comment.UserName = User.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Name).Value;
            comment.CommentDate = DateTime.Now;
            comment.Like = 0;
            comment.pictureID = 0;
            rImageComment.Add(comment);
            return RedirectToAction("Resim");
        }

        public IActionResult Yapilar()
        {
            return View();
        }
        public IActionResult Ayasofya()
        {
            return View();
        }
        public IActionResult Unity()
        {
            return View();
        }
        




    }
}
