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
using AnywayStore.Helper;

namespace AnywayStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly Repository<ClassEntityUsers> repositoryUsers = new Repository<ClassEntityUsers>(NHibernateHelper.OpenSession());

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
            var config = WebConfigurationManager.OpenWebConfiguration("~");
            bool isFistInit = bool.Parse(config.AppSettings.Settings["FistInit"].Value);

            if (isFistInit) FistRun();

            config.AppSettings.Settings["FistInit"].Value = "false";
            config.Save();

            return View();
        }

        public ActionResult Admin()
        {
            return View();
        }

        private Task FistRun()
        {
            var repositoryBrands = new Repository<ClassEntityBrands>(NHibernateHelper.OpenSession());
            var repositoryCategories = new Repository<ClassEntityCategories>(NHibernateHelper.OpenSession());
            var repositoryRoles = new Repository<ClassEntityRoles>(NHibernateHelper.OpenSession());
            var repositorySizes = new Repository<ClassEntitySizes>(NHibernateHelper.OpenSession());

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

                    repositoryBrands.Add(new List<ClassEntityBrands>() {
                        new ClassEntityBrands(){ Name = "Abercrombie"},
                        new ClassEntityBrands(){ Name = "Asos"},
                        new ClassEntityBrands(){ Name = "Bershka"},
                        new ClassEntityBrands(){ Name = "Missguided"},
                        new ClassEntityBrands(){ Name = "Zara"}
                    });

                    repositoryCategories.Add(new List<ClassEntityCategories>() {
                        new ClassEntityCategories(){ Name = "Woman"},
                        new ClassEntityCategories(){ Name = "Midi Dresses"},
                        new ClassEntityCategories(){ Name = "Maxi Dresses"},
                        new ClassEntityCategories(){ Name = "Prom Dresses"},
                        new ClassEntityCategories(){ Name = "Little Black Dresses"},
                        new ClassEntityCategories(){ Name = "Mini Dresses"},
                        new ClassEntityCategories(){ Name = "Man"},
                        new ClassEntityCategories(){ Name = "Children"},
                        new ClassEntityCategories(){ Name = "Bags & Purses"},
                        new ClassEntityCategories(){ Name = "Eyewear"},
                        new ClassEntityCategories(){ Name = "Footwear"}
                    });

                    repositoryRoles.Add(new List<ClassEntityRoles>() {
                        new ClassEntityRoles(){ Name = "admin"},
                        new ClassEntityRoles(){ Name = "customer"},
                        new ClassEntityRoles(){ Name = "seller"}
                    });

                    repositorySizes.Add(new List<ClassEntitySizes>() {
                        new ClassEntitySizes(){ Name = "XS"},
                        new ClassEntitySizes(){ Name = "S"},
                        new ClassEntitySizes(){ Name = "M"},
                        new ClassEntitySizes(){ Name = "L"},
                        new ClassEntitySizes(){ Name = "XL"},
                        new ClassEntitySizes(){ Name = "XXL"},
                    });

                    var _user = new ClassEntityUsers()
                    {
                        Name = model.Name,
                        Tel = model.PhoneNumber,
                        EntityRoles = repositoryRoles.FindBy(1),
                        IdLogin = user.Id
                    };

                    repositoryUsers.Add(_user);
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