using AnywayStore.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnywayStore.Maps
{
    public class ClassMapRoles: ClassMap<ClassEntityRoles>
    {
        public ClassMapRoles()
        {
            Id(field => field.IdRol).GeneratedBy.Native();
            Map(field => field.Name).Length(50).Not.Nullable();

            Table("Roles");
        }
    }
}