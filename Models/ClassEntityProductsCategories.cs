using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnywayStore.Models
{
    public class ClassEntityProductsCategories
    {
        public virtual ClassEntityProducts EntityProducts { get; set; }
        public virtual ClassEntityCategories EntityCategories { get; set; }
        public virtual int IdProductCategory { get; set; }
    }
}