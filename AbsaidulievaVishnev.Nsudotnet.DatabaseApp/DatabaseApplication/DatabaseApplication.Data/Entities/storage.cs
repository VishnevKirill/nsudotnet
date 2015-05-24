namespace DatabaseApplication.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("storage")]
    public partial class storage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int cell { get; set; }

        public int? order_id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? good_volume { get; set; }

        [Column(TypeName = "numeric")]
        public decimal cell_volume { get; set; }

        public virtual customs customs { get; set; }
    }
}
