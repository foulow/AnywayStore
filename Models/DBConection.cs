namespace AnywayStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;

    public class DBConection
    {
        public DBConection()
        {

        }

        public string StringConnection { get; set; }
    }
}