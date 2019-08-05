using AnywayStore.Helper;
using AnywayStore.Models;
using AnywayStore.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AnywayStore.Controllers
{
    public class SellerController : Controller
    {
        private Repository<ClassEntityProducts> repositoryProducts = new Repository<ClassEntityProducts>(NHibernateHelper.OpenSession());
        private Repository<ClassEntitySizes> repositorySizes = new Repository<ClassEntitySizes>(NHibernateHelper.OpenSession());
        private Repository<ClassEntityBrands> repositoryBrands = new Repository<ClassEntityBrands>(NHibernateHelper.OpenSession());
        private Repository<ClassEntityCategories> repositoryCategories = new Repository<ClassEntityCategories>(NHibernateHelper.OpenSession());
        private Repository<ClassEntityUsers> repositoryUsers = new Repository<ClassEntityUsers>(NHibernateHelper.OpenSession());
        private Repository<ClassEntityProductsCategories> repositoryProductsCategories = new Repository<ClassEntityProductsCategories>(NHibernateHelper.OpenSession());
        private Repository<ClassEntityProductsSizes> repositoryProductsSizes = new Repository<ClassEntityProductsSizes>(NHibernateHelper.OpenSession());
        
        // GET: Seller
        [Authorize]
        public ActionResult Index(int idProduct = 0)
        {
            ViewBag.Sizes = repositorySizes.All();
            ViewBag.Brands = repositoryBrands.All();
            ViewBag.Categories = repositoryCategories.All();

            if (idProduct != 0)
            {
                var product = new ViewModelProducts() { EntityProducts = repositoryProducts.FindBy(idProduct) };

                product.CategoriesId = new int[product.EntityProducts.EntityProductsCategories.Count];
                product.SizesId = new int[product.EntityProducts.EntityProductsSizes.Count];

                for (var i = 0; i < product.EntityProducts.EntityProductsCategories.Count; i++) product.CategoriesId[i] = product.EntityProducts.EntityProductsCategories[i].EntityCategories.IdCategory;
                for (var i = 0; i < product.EntityProducts.EntityProductsSizes.Count; i++) product.SizesId[i] = product.EntityProducts.EntityProductsSizes[i].EntitySizes.IdSize;

                return View(product);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Sell(ViewModelProducts product)
        {
            var idlogin = User.Identity.GetUserId();

            product.EntityProducts.EntityUsers = repositoryUsers.FindBy(field => field.IdLogin == User.Identity.GetUserId()).FirstOrDefault();
            product.EntityProducts.Posted = DateTime.Now;
            product.EntityProducts.OnSale = false;

            foreach (var idCategory in product.CategoriesId)
            {
                var category = repositoryCategories.FindBy(idCategory);
                product.EntityProducts.EntityProductsCategories.Add(new ClassEntityProductsCategories { EntityCategories = category, EntityProducts = product.EntityProducts });
            }

            foreach (var idSize in product.SizesId)
            {
                var Size = repositorySizes.FindBy(idSize);
                product.EntityProducts.EntityProductsSizes.Add(new ClassEntityProductsSizes { EntitySizes = Size, EntityProducts = product.EntityProducts });
            }

            if (product.EntityProducts.IdProduct == 0)
                repositoryProducts.Add(product.EntityProducts);
            else
                repositoryProducts.Update(product.EntityProducts);

            var x = 1;
            string strpath = Server.MapPath("~/img/product/" + product.EntityProducts.IdProduct.ToString());
            if (!(Directory.Exists(strpath)))
            {
                Directory.CreateDirectory(strpath);

                foreach (var file in product.EntityProducts.Files)
                {
                    if (file != null)
                    {
                        var InputFileName = Path.GetFileName(x++.ToString() + "." + file.FileName.Split('.')[1]);
                        var ServerSavePath = Path.Combine(strpath + "/" + InputFileName);
                        //Save file to server folder  
                        file.SaveAs(ServerSavePath);
                    }
                }
            }

            return RedirectToAction("Products", "Seller");
        }

        [Authorize]
        public ActionResult Products()
        {
            var user = repositoryUsers.FindBy(field => field.IdLogin == User.Identity.GetUserId()).FirstOrDefault();
            var products = repositoryProducts.FindBy(field => field.EntityUsers.IdUser == user.IdUser);

            return View(products);
        }
    }
}