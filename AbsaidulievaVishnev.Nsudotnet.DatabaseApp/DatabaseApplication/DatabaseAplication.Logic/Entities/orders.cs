namespace DatabaseApplication.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class orders : NumerableEntity
    {
        public int id { get; set; }

        public int good_id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal quantyty { get; set; }

        public int? aplications_id { get; set; }

        public int manager_id { get; set; }

        public int providers_id { get; set; }

        public virtual applications applications { get; set; }

        public virtual customs customs { get; set; }

        public virtual goods goods { get; set; }

        public virtual managers managers { get; set; }

        public virtual providers providers { get; set; }
    }
}
