namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_lkup_frequency
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_lkup_frequency()
        {
            t_dis_returns = new HashSet<t_dis_returns>();
            t_rpt_computation_rule_frequency = new HashSet<t_rpt_computation_rule_frequency>();
            t_rtn_returns = new HashSet<t_rtn_returns>();
            t_rtn_work_collection = new HashSet<t_rtn_work_collection>();
            t_rtn_work_collection_defn = new HashSet<t_rtn_work_collection_defn>();
            t_rpt_computation_value_table = new HashSet<t_rpt_computation_value_table>();
            t_pnt_penalty_definition = new HashSet<t_pnt_penalty_definition>();
            t_pnt_penalty_definition1 = new HashSet<t_pnt_penalty_definition>();
        }

        [Key]
        [StringLength(2)]
        public string freq_unit { get; set; }

        [Required]
        [StringLength(128)]
        public string freq_name { get; set; }

        [Required]
        [StringLength(1000)]
        public string freq_desc { get; set; }

        public int freq_in_days { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_dis_returns> t_dis_returns { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rpt_computation_rule_frequency> t_rpt_computation_rule_frequency { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rtn_returns> t_rtn_returns { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rtn_work_collection> t_rtn_work_collection { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rtn_work_collection_defn> t_rtn_work_collection_defn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rpt_computation_value_table> t_rpt_computation_value_table { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_pnt_penalty_definition> t_pnt_penalty_definition { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_pnt_penalty_definition> t_pnt_penalty_definition1 { get; set; }
    }
}
