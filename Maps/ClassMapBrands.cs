using AnywayStore.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnywayStore.Maps
{
    public class ClassMapBrands: ClassMap<ClassEntityBrands>
    {
        public ClassMapBrands()
        {
            Id(field => field.IdBrand).GeneratedBy.Native();
            Map(field => field.Name).Length(50).Not.Nullable();

            Table("Brands");
        }
    }
}