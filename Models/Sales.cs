namespace AnywayStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sales
    {
        public int id { get; set; }

        public int cuantity { get; set; }

        public int? product_id { get; set; }

        public int? user_id { get; set; }

        public virtual Products Products { get; set; }

        public virtual Users Users { get; set; }
    }
}
