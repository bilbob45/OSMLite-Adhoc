namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_lkup_contravention_type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_lkup_contravention_type()
        {
            t_pnt_penalty_formula = new HashSet<t_pnt_penalty_formula>();
            t_rpt_contravention_valuation = new HashSet<t_rpt_contravention_valuation>();
        }

        [Key]
        [StringLength(120)]
        public string contravention_type { get; set; }

        [Required]
        [StringLength(256)]
        public string name { get; set; }

        [Required]
        [StringLength(1024)]
        public string description { get; set; }

        [StringLength(2)]
        public string penalty_value { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_pnt_penalty_formula> t_pnt_penalty_formula { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rpt_contravention_valuation> t_rpt_contravention_valuation { get; set; }
    }
}
