using AnywayStore.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnywayStore.Maps
{
    public class ClassMapProductsSizes: ClassMap<ClassEntityProductsSizes>
    {
        public ClassMapProductsSizes()
        {
            Id(field => field.IdProductSize).GeneratedBy.Native();

            References(field => field.EntityProducts).Column("IdProduct").ForeignKey("FK_ProductsSizes_Products");
            References(field => field.EntitySizes).Column("IdSize").ForeignKey("FK_ProductsSizes_Sizes");

            Table("ProductsSizes");
        }
    }
}