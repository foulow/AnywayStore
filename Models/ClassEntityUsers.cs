using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
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

        [ScriptIgnore]
        public virtual IList<ClassEntityUsersProducts> EntityUsersProducts { get; set; }

        [ScriptIgnore]
        public virtual IList<ClassEntityProducts> EntityProducts { get; set; }

        public ClassEntityUsers()
        {
            EntityUsersProducts = new List<ClassEntityUsersProducts>();
            EntityProducts = new List<ClassEntityProducts>();
        }
    }
}