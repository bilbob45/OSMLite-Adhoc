namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_currency_rate_type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_currency_rate_type()
        {
            t_currency_rate = new HashSet<t_currency_rate>();
        }

        [Key]
        [StringLength(10)]
        public string rate_type { get; set; }

        [Required]
        [StringLength(1024)]
        public string rate_desc { get; set; }

        public int rate_life { get; set; }

        public bool rate_active { get; set; }

        public DateTime last_modified { get; set; }

        [Required]
        [StringLength(255)]
        public string modified_by { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_currency_rate> t_currency_rate { get; set; }
    }
}
