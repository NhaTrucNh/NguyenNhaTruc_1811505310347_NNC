namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [StringLength(10)]
        public string ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public decimal UnitCost { get; set; }

        public int Quantity { get; set; }

        [Required]
        [StringLength(10)]
        public string Category { get; set; }

        [Required]
        [StringLength(350)]
        public string Image { get; set; }

        [Required]
        [StringLength(550)]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        public virtual Category Category1 { get; set; }
    }
}
