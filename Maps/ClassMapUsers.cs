using AnywayStore.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnywayStore.Maps
{
    public class ClassMapUsers: ClassMap<ClassEntityUsers>
    {
        public ClassMapUsers()
        {
            Id(field => field.IdUser).GeneratedBy.Native();
            Map(field => field.Name).Length(50).Not.Nullable();
            Map(field => field.Tel).Length(12).Nullable();
            Map(field => field.IdLogin);

            References(field => field.EntityRoles).Column("IdRol").ForeignKey("FK_Users_Roles");

            Table("Users");
        }
    }
}