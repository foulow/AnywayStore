using AnywayStore.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnywayStore.Maps
{
    public class ClassMapUsersProducts: ClassMap<ClassEntityUsersProducts>
    {
        public ClassMapUsersProducts()
        {
            Id(field => field.IdUserProduct).GeneratedBy.Native();
            Map(field => field.Quantity);

            References(field => field.EntityUsers).Column("IdUser").ForeignKey("FK_UsersProducts_Users");
            References(field => field.EntityProducts).Column("IdProduct").ForeignKey("FK_UsersProducts_Products");
            References(field => field.EntitySizes).Column("IdSize").ForeignKey("FK_UsersProducts_Sizes");

            Table("UsersProducts");
        }
    }
}