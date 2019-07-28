using AnywayStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Web.Configuration;

namespace AnywayStore.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ActionResult Index()
        {
            //var config = WebConfigurationManager.OpenWebConfiguration("~");
            //bool isFistInit = bool.Parse(config.AppSettings.Settings["FistInit"].Value);

            //if (isFistInit) FistRun();

            //config.AppSettings.Settings["FistInit"].Value = "false";
            //config.Save();

            return View();
        }

        public ActionResult Admin()
        {
            return View();
        }

        private Task FistRun()
        {
            return Task.Run(async () =>
            {
                var model = new RegisterViewModel
                {
                    Email = "admin@admin.com",
                    Password = "Admin.tienda1",
                    ConfirmPassword = "Admin.tienda1",
                    Name = "Web Administrator",
                    PhoneNumber = "000-000-0000",
                    SelectedRole = "admin"
                };

                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    //using (var dBSet = new DBSet())
                    //{
                    //    var _user = new Users
                    //    {
                    //        name = model.Name,
                    //        tel = model.PhoneNumber,
                    //        role_id = dBSet.Roles.First(m => m.name == model.SelectedRole).id,
                    //        login_id = user.Id
                    //    };

                    //    dBSet.Users.Add(_user);
                    //    await dBSet.SaveChangesAsync();
                    //}
                }
            });
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}