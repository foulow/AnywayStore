using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AnywayStore.Helper;
using AnywayStore.Models;
using Microsoft.AspNet.Identity;

namespace AnywayStore.Controllers
{
    public class ProductsController : Controller
    {
        private readonly Repository<ClassEntityProducts> repositoryProducts = new Repository<ClassEntityProducts>(NHibernateHelper.OpenSession());
        private readonly Repository<ClassEntityCategories> repositoryCategories = new Repository<ClassEntityCategories>(NHibernateHelper.OpenSession());
        private readonly Repository<ClassEntityProductsCategories> repositoryProductsCategories = new Repository<ClassEntityProductsCategories>(NHibernateHelper.OpenSession());
        private readonly Repository<ClassEntityBrands> repositoryBrands = new Repository<ClassEntityBrands>(NHibernateHelper.OpenSession());
        private readonly Repository<ClassEntityUsers> repositoryUsers = new Repository<ClassEntityUsers>(NHibernateHelper.OpenSession());
        // GET: Products
        private static int take = 12;
        public ActionResult Index(string find = null)
        {            
            take = 12;

            ViewBag.Find = find;

            return View();
        }

        public ActionResult Products(string find = null)
        {
            IList<ClassEntityProducts> products = new List<ClassEntityProducts>();

            if (find == null || find == "")
            {
                products = repositoryProducts.All();
            }
            else
            {
                find = find.ToUpper();
                var categories = repositoryCategories.FindBy(field => field.Name.ToUpper().Contains(find));

                if (categories.Count > 0)
                {
                    var productsCategories = new List<ClassEntityProductsCategories>();

                    foreach (var category in categories)
                    {
                        productsCategories.AddRange(repositoryProductsCategories.FindBy(field => field.EntityCategories.IdCategory == category.IdCategory));
                    }

                    foreach (var productCategory in productsCategories)
                    {
                        products.Add(productCategory.EntityProducts);
                    }
                }

                var foundProducts = repositoryProducts.FindBy(field => field.Name.ToUpper().Contains(find) || field.EntityBrand.Name.ToUpper().Contains(find));
                foreach (var product in foundProducts)
                {
                    products.Add(product);
                }
            }

            products.Take(take).ToList();

            take += 12;

            return PartialView(products);
        }

        // GET: Products/Details/5
        public ActionResult Product(int? idProduct)
        {
            var product = repositoryProducts.FindBy(idProduct.Value);
            var user = repositoryUsers.FindBy(field => field.IdLogin == User.Identity.GetUserId()).FirstOrDefault();

            var files = new DirectoryInfo(Server.MapPath("~/img/product/" + idProduct.ToString())).GetFiles();
            List<string> filesNames = new List<string>();

            foreach (var file in files)
                filesNames.Add(file.Name);

            ViewBag.Images = filesNames;
            ViewBag.Users = user;

            return View(product);
        }

        public ActionResult Related()
        {
            var products = repositoryProducts.All();

            return PartialView(products);
        }

        public ActionResult Categories()
        {
            var categories = repositoryCategories.All();

            return PartialView(categories);
        }

        public ActionResult Brands()
        {
            var brands = repositoryBrands.All();

            return PartialView(brands);
        }
    }
}
