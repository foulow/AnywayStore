using AnywayStore.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnywayStore.Maps
{
    public class ClassMapCategories: ClassMap<ClassEntityCategories>
    {
        public ClassMapCategories()
        {
            Id(field => field.IdCategory).GeneratedBy.Native();
            Map(field => field.Name).Length(50).Not.Nullable();

            HasMany(field => field.EntityProductsCategories)
                .KeyColumn("IdCategory")
                .Inverse()
                .Cascade
                .All();

            Table("Categories");
        }
    }
}