namespace DatabaseApplication.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class provider_goods
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int good_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int provider_id { get; set; }

        public DateTime time_of_deliverly { get; set; }

        [Column(TypeName = "numeric")]
        public decimal deliverly_cost { get; set; }

        public virtual goods goods { get; set; }

        public virtual providers providers { get; set; }
    }
}
