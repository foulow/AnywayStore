using AnywayStore.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnywayStore.Maps
{
    public class ClassMapSizes: ClassMap<ClassEntitySizes>
    {
        public ClassMapSizes()
        {
            Id(field => field.IdSize).GeneratedBy.Native();
            Map(field => field.Name).Length(50).Not.Nullable();

            Table("Sizes");
        }
    }
}