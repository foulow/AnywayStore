namespace AnywayStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Products
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Products()
        {
            Sales = new HashSet<Sales>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; }

        public int stock { get; set; }

        public int price { get; set; }

        [Required]
        [StringLength(50)]
        public string measurement { get; set; }

        [Required]
        [StringLength(25)]
        public string style { get; set; }

        [Required]
        [StringLength(25)]
        public string color { get; set; }

        public int? category_id { get; set; }

        public int? user_id { get; set; }

        public virtual Categories Categories { get; set; }

        public virtual Users Users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sales> Sales { get; set; }
    }
}
