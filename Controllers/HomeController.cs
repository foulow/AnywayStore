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
                        new ClassEntityBrands(){ Name = "abercrombie"},
                        new ClassEntityBrands(){ Name = "asos"},
                        new ClassEntityBrands(){ Name = "bershka"},
                        new ClassEntityBrands(){ Name = "missguided"},
                        new ClassEntityBrands(){ Name = "zara"}
                    });

                    repositoryCategories.Add(new List<ClassEntityCategories>() {
                        new ClassEntityCategories(){ Name = "woman"},
                        new ClassEntityCategories(){ Name = "midi dresses"},
                        new ClassEntityCategories(){ Name = "maxi dresses"},
                        new ClassEntityCategories(){ Name = "prom dresses"},
                        new ClassEntityCategories(){ Name = "little black dresses"},
                        new ClassEntityCategories(){ Name = "mini dresses"},
                        new ClassEntityCategories(){ Name = "man"},
                        new ClassEntityCategories(){ Name = "children"},
                        new ClassEntityCategories(){ Name = "bags & purses"},
                        new ClassEntityCategories(){ Name = "eyewear"},
                        new ClassEntityCategories(){ Name = "footwear"},
                        new ClassEntityCategories(){ Name = "jumpsuits"},
                        new ClassEntityCategories(){ Name = "lingerie"},
                        new ClassEntityCategories(){ Name = "jeans"},
                        new ClassEntityCategories(){ Name = "dresses"},
                        new ClassEntityCategories(){ Name = "coats"},
                        new ClassEntityCategories(){ Name = "jumpers"},
                        new ClassEntityCategories(){ Name = "leggins"}
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

                    model = new RegisterViewModel
                    {
                        Email = "customer@customer.com",
                        Password = "Customer.tienda1",
                        ConfirmPassword = "Customer.tienda1",
                        Name = "Web Customer",
                        PhoneNumber = "000-000-0000",
                        SelectedRole = "customer"
                    };

                    user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                    result = await UserManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        _user = new ClassEntityUsers()
                        {
                            Name = model.Name,
                            Tel = model.PhoneNumber,
                            EntityRoles = repositoryRoles.FindBy(2),
                            IdLogin = user.Id
                        };

                        repositoryUsers.Add(_user);

                        model = new RegisterViewModel
                        {
                            Email = "seller@seller.com",
                            Password = "Seller.tienda1",
                            ConfirmPassword = "Seller.tienda1",
                            Name = "Web Seller",
                            PhoneNumber = "000-000-0000",
                            SelectedRole = "seller"
                        };

                        user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                        result = await UserManager.CreateAsync(user, model.Password);
                        if (result.Succeeded)
                        {
                            _user = new ClassEntityUsers()
                            {
                                Name = model.Name,
                                Tel = model.PhoneNumber,
                                EntityRoles = repositoryRoles.FindBy(3),
                                IdLogin = user.Id
                            };

                            repositoryUsers.Add(_user);
                        }
                    }
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