using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace AnywayStore.Models
{
    public class ClassEntityProducts
    {
        public virtual ClassEntityBrands EntityBrand { get; set; }
        public virtual ClassEntityColors EntityColors { get; set; }
        public virtual ClassEntitySizes EntitySizes { get; set; }
        public virtual int IdProduct { get; set; }
        public virtual string Name { get; set; }
        public virtual string Information { get; set; }
        public virtual decimal Price { get; set; }
        public virtual int Stock { get; set; }

        [ScriptIgnore]
        public virtual IList<ClassEntityProductsCategories> EntityProductsCategories { get; set; }

        public ClassEntityProducts()
        {
            EntityProductsCategories = new List<ClassEntityProductsCategories>();
        }
    }
}