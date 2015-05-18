namespace DatabaseApplication.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class providers : NumerableEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public providers()
        {
            orders = new HashSet<orders>();
            provider_goods = new HashSet<provider_goods>();
            attribute_value = new HashSet<attribute_value>();
        }

        public int id { get; set; }

        public int country_id { get; set; }

        public int category_id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        public virtual countries countries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<orders> orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<provider_goods> provider_goods { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<attribute_value> attribute_value { get; set; }

        public virtual providers_category providers_category { get; set; }
    }
}
