using AnywayStore.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnywayStore.Maps
{
    public class ClassMapProductsCategories: ClassMap<ClassEntityProductsCategories>
    {
        public ClassMapProductsCategories()
        {
            Id(field => field.IdProductCategory).GeneratedBy.Native();

            References(field => field.EntityProducts).Column("IdProduct").ForeignKey("FK_ProductsCategories_Products");
            References(field => field.EntityCategories).Column("IdCategory").ForeignKey("FK_ProductsCategories_Categories");

            Table("ProductsCategories");
        }
    }
}