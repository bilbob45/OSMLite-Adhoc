namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_lkup_business_month_convention
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_lkup_business_month_convention()
        {
            t_dis_ri_eod_date = new HashSet<t_dis_ri_eod_date>();
        }

        [Key]
        [StringLength(20)]
        public string business_month_convention_code { get; set; }

        [Required]
        [StringLength(128)]
        public string business_month_convention_name { get; set; }

        [Required]
        [StringLength(1000)]
        public string business_month_convention_desc { get; set; }

        public DateTime date_created { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_dis_ri_eod_date> t_dis_ri_eod_date { get; set; }
    }
}
