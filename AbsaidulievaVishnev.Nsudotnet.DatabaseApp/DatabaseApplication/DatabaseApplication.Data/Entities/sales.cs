namespace DatabaseApplication.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sales
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int good_id { get; set; }

        public int sales_volume { get; set; }

        [Column(TypeName = "numeric")]
        public decimal cost { get; set; }

        public virtual goods goods { get; set; }
    }
}
