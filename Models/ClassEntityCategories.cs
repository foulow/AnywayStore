using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace AnywayStore.Models
{
    public class ClassEntityCategories
    {
        public virtual int IdCategory { get; set; }
        public virtual string Name { get; set; }

        [ScriptIgnore]
        public virtual IList<ClassEntityProductsCategories> EntityProductsCategories { get; set; }

        public ClassEntityCategories()
        {
            EntityProductsCategories = new List<ClassEntityProductsCategories>();
        }
    }
}