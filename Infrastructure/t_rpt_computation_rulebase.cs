namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rpt_computation_rulebase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_rpt_computation_rulebase()
        {
            t_rpt_computation_rulemakeup = new HashSet<t_rpt_computation_rulemakeup>();
            t_rpt_computation_rulemakeup_formula = new HashSet<t_rpt_computation_rulemakeup_formula>();
            t_rpt_computation_rulemakeup1 = new HashSet<t_rpt_computation_rulemakeup>();
            t_rpt_computation_rulemakeup_formula1 = new HashSet<t_rpt_computation_rulemakeup_formula>();
        }

        [Key]
        public int rule_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string rule_Name { get; set; }

        [Required]
        [StringLength(500)]
        public string rule_Desc { get; set; }

        public int? version_id { get; set; }

        [StringLength(20)]
        public string rule_status { get; set; }

        [Required]
        [StringLength(4000)]
        public string formula { get; set; }

        [Required]
        [StringLength(40)]
        public string type { get; set; }

        public int? ruleColumnNos { get; set; }

        public int? ruleRowNos { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }

        [StringLength(25)]
        public string rule_freq { get; set; }

        [StringLength(25)]
        public string rule_ri { get; set; }

        [StringLength(20)]
        public string trend { get; set; }

        [StringLength(2)]
        public string is_global { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rpt_computation_rulemakeup> t_rpt_computation_rulemakeup { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rpt_computation_rulemakeup_formula> t_rpt_computation_rulemakeup_formula { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rpt_computation_rulemakeup> t_rpt_computation_rulemakeup1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rpt_computation_rulemakeup_formula> t_rpt_computation_rulemakeup_formula1 { get; set; }
    }
}
