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

namespace AnywayStore.Controllers
{
    public class ProductsController : Controller
    {
        private readonly Repository<ClassEntityProducts> repositoryProducts = new Repository<ClassEntityProducts>(NHibernateHelper.OpenSession());
        private readonly Repository<ClassEntityCategories> repositoryCategories = new Repository<ClassEntityCategories>(NHibernateHelper.OpenSession());
        private readonly Repository<ClassEntityProductsCategories> repositoryProductsCategories = new Repository<ClassEntityProductsCategories>(NHibernateHelper.OpenSession());
        private readonly Repository<ClassEntityBrands> repositoryBrands = new Repository<ClassEntityBrands>(NHibernateHelper.OpenSession());
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
                var category = repositoryCategories.FindBy(field => field.Name.Contains(find)).FirstOrDefault();

                if (category != null)
                {
                    var productsCategories = repositoryProductsCategories.FindBy(field => field.EntityCategories.IdCategory == category.IdCategory);

                    foreach (var productCategory in productsCategories)
                    {
                        products.Add(productCategory.EntityProducts);
                    }
                }

                var foundProducts = repositoryProducts.FindBy(field => field.Name.Contains(find));
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

            var files = new DirectoryInfo(Server.MapPath("~/img/product/" + idProduct.ToString())).GetFiles();
            List<string> filesNames = new List<string>();

            foreach (var file in files)
                filesNames.Add(file.Name);

            ViewBag.Images = filesNames;

            return View(product);
        }
    }
}
