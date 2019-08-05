using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnywayStore.Helper;

namespace AnywayStore.Models
{
    public class ClassEntityUsers
    {
        public virtual ClassEntityRoles EntityRoles { get; set; }
        public virtual int IdUser { get; set; }
        public virtual string Name { get; set; }
        public virtual string Tel { get; set; }
        public virtual string IdLogin { get; set; }
    }
}