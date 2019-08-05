using AnywayStore.Helper;
using AnywayStore.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnywayStore.Controllers
{
    public class CartController : Controller
    {
        private Repository<ClassEntityUsersProducts> repositoryUsersProducts = new Repository<ClassEntityUsersProducts>(NHibernateHelper.OpenSession());
        private Repository<ClassEntityUsers> repositoryUsers = new Repository<ClassEntityUsers>(NHibernateHelper.OpenSession());
        private Repository<ClassEntitySizes> repositorySizes = new Repository<ClassEntitySizes>(NHibernateHelper.OpenSession());

        [Authorize]
        public ActionResult Index()
        {
            var user = repositoryUsers.FindBy(field => field.IdLogin == User.Identity.GetUserId()).FirstOrDefault();

            var cart = repositoryUsersProducts.FindBy(field => field.EntityUsers.IdUser == user.IdUser);

            return View(cart);
        }

        public ActionResult Cart()
        {
            var user = repositoryUsers.FindBy(field => field.IdLogin == User.Identity.GetUserId()).FirstOrDefault();
            var inCart = repositoryUsersProducts.FindBy(field => field.EntityUsers.IdUser == user.IdUser).Count;

            return PartialView(inCart);
        }

        public ActionResult Checkout()
        {
            return View();
        }

        public ActionResult Add(ClassEntityProducts entityProducts, string size, int quantity)
        {
            var entitySize = repositorySizes.FindBy(field => field.Name == size.ToUpper()).FirstOrDefault();
            var product = new ClassEntityUsersProducts() {
                EntityUsers = repositoryUsers.FindBy(field => field.IdLogin == User.Identity.GetUserId()).FirstOrDefault(),
                EntityProducts = entityProducts,
                EntitySizes = entitySize,
                Quantity = quantity,
            };

            repositoryUsersProducts.Add(product);

            return Json("");
        }
    }
}