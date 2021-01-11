namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_lkup_computation_rule_exec_status
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_lkup_computation_rule_exec_status()
        {
            t_rpt_computation_rule_run_status = new HashSet<t_rpt_computation_rule_run_status>();
        }

        [Key]
        [StringLength(1)]
        public string exec_status { get; set; }

        [Required]
        [StringLength(1024)]
        public string description { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rpt_computation_rule_run_status> t_rpt_computation_rule_run_status { get; set; }
    }
}
