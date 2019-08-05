using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnywayStore.Models
{
    public class ClassEntityUsersProducts
    {
        public virtual ClassEntityUsers EntityUsers { get; set; }
        public virtual ClassEntityProducts EntityProducts { get; set; }
        public virtual ClassEntitySizes EntitySizes { get; set; }
        public virtual int IdUserProduct { get; set; }
        public virtual int Quantity { get; set; }
    }
}