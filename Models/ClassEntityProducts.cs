using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace AnywayStore.Models
{
    public class ClassEntityProducts
    {
        public virtual ClassEntityUsers EntityUsers { get; set; }
        public virtual ClassEntityBrands EntityBrand { get; set; }
        public virtual int IdProduct { get; set; }

        [Required(ErrorMessage = "The Title is Required")]
        public virtual string Name { get; set; }

        [Required(ErrorMessage = "The Information is Required")]
        public virtual string Information { get; set; }

        [Required(ErrorMessage = "The Price is Required")]
        [Range(0, 99999.99f)]
        public virtual decimal Price { get; set; }
        public virtual int Stock { get; set; }
        public virtual bool? OnSale { get; set; }
        public virtual DateTime? Posted { get; set; }

        [Required(ErrorMessage = "Please select file.")]
        [Display(Name = "Browse File")]
        public virtual HttpPostedFileBase[] Files { get; set; }

        [ScriptIgnore]
        public virtual IList<ClassEntityProductsCategories> EntityProductsCategories { get; set; }

        [ScriptIgnore]
        public virtual IList<ClassEntityProductsSizes> EntityProductsSizes { get; set; }

        public ClassEntityProducts()
        {
            EntityProductsCategories = new List<ClassEntityProductsCategories>();
            EntityProductsSizes = new List<ClassEntityProductsSizes>();
        }
    }
}