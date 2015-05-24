namespace DatabaseApplication.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cash")]
    public partial class cash
    {
        [Key]
        public int operation_id { get; set; }

        public int good_id { get; set; }

        [Required]
        [StringLength(1)]
        public string typ { get; set; }

        public int order_id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal number_of_good { get; set; }

        [Column(TypeName = "numeric")]
        public decimal cost { get; set; }

        [Required]
        [StringLength(10)]
        public string act { get; set; }

        [Column(TypeName = "date")]
        public DateTime date_of_action { get; set; }

        public int? buyer_id { get; set; }

        public virtual buyers buyers { get; set; }

        public virtual goods goods { get; set; }

        public virtual customs customs { get; set; }
    }
}
