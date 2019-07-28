using AnywayStore.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnywayStore.Maps
{
    public class ClassMapColors: ClassMap<ClassEntityColors>
    {
        public ClassMapColors()
        {
            Id(field => field.IdColor).GeneratedBy.Native();
            Map(field => field.Name).Length(50).Not.Nullable();

            Table("Colors");
        }
    }
}