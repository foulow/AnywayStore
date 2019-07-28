using AnywayStore.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnywayStore.Maps
{
    public class ClassMapProducts: ClassMap<ClassEntityProducts>
    {
        public ClassMapProducts()
        {
            Id(field => field.IdProduct).GeneratedBy.Native();
            Map(field => field.Name).Length(50).Not.Nullable();
            Map(field => field.Information).CustomType("StringClob").Not.Nullable();
            Map(field => field.Price).Precision(14).Not.Nullable();
            Map(field => field.Stock).Not.Nullable();

            References(field => field.EntityBrand).Column("IdBrand").ForeignKey("FK_Products_Brands");
            References(field => field.EntityColors).Column("IdColor").ForeignKey("FK_Products_Colors");
            References(field => field.EntitySizes).Column("IdSize").ForeignKey("FK_Products_Sizes");

            HasMany(field => field.EntityProductsCategories)
                .KeyColumn("IdProduct")
                .Inverse()
                .Cascade
                .All();

            Table("Products");
        }
    }
}