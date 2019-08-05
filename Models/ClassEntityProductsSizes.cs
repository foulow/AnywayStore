using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnywayStore.Models
{
    public class ClassEntityProductsSizes
    {
        public virtual ClassEntityProducts EntityProducts { get; set; }
        public virtual ClassEntitySizes EntitySizes { get; set; }
        public virtual int IdProductSize { get; set; }
    }
}