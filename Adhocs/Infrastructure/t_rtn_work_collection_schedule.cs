namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rtn_work_collection_schedule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_rtn_work_collection_schedule()
        {
            t_rpt_computation_rule_adjustment = new HashSet<t_rpt_computation_rule_adjustment>();
            t_rpt_computation_rule_run_status = new HashSet<t_rpt_computation_rule_run_status>();
            t_rpt_computation_value = new HashSet<t_rpt_computation_value>();
            t_rpt_computation_value_cmb000 = new HashSet<t_rpt_computation_value_cmb000>();
            t_rpt_computation_value_simple = new HashSet<t_rpt_computation_value_simple>();
            t_rtn_detailed_imf_srf_cmb = new HashSet<t_rtn_detailed_imf_srf_cmb>();
            t_rtn_detailed_imf_srf_ins = new HashSet<t_rtn_detailed_imf_srf_ins>();
            t_rtn_detailed_imf_srf_mfb = new HashSet<t_rtn_detailed_imf_srf_mfb>();
            t_rtn_detailed_imf_srf_nib = new HashSet<t_rtn_detailed_imf_srf_nib>();
            t_rtn_detailed_imf_srf_pen = new HashSet<t_rtn_detailed_imf_srf_pen>();
            t_rtn_detailed_imf_srf_pmb = new HashSet<t_rtn_detailed_imf_srf_pmb>();
            t_rtn_work_collection_submission = new HashSet<t_rtn_work_collection_submission>();
        }

        [Key]
        public long schedule_id { get; set; }

        public int ri_id { get; set; }

        public int work_collection_id { get; set; }

        public DateTime work_collection_date { get; set; }

        public DateTime? schedule_deadline { get; set; }

        public int? workflow_id { get; set; }

        public int status_id { get; set; }

        public bool resubmit_req { get; set; }

        public int resubmit_count { get; set; }

        public int validation_count { get; set; }

        public bool is_valid { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }

        public virtual t_core_reporting_institution t_core_reporting_institution { get; set; }

        public virtual t_lkup_wc_schedule_status t_lkup_wc_schedule_status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rpt_computation_rule_adjustment> t_rpt_computation_rule_adjustment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rpt_computation_rule_run_status> t_rpt_computation_rule_run_status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rpt_computation_value> t_rpt_computation_value { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rpt_computation_value_cmb000> t_rpt_computation_value_cmb000 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rpt_computation_value_simple> t_rpt_computation_value_simple { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rtn_detailed_imf_srf_cmb> t_rtn_detailed_imf_srf_cmb { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rtn_detailed_imf_srf_ins> t_rtn_detailed_imf_srf_ins { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rtn_detailed_imf_srf_mfb> t_rtn_detailed_imf_srf_mfb { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rtn_detailed_imf_srf_nib> t_rtn_detailed_imf_srf_nib { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rtn_detailed_imf_srf_pen> t_rtn_detailed_imf_srf_pen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rtn_detailed_imf_srf_pmb> t_rtn_detailed_imf_srf_pmb { get; set; }

        public virtual t_rtn_work_collection_defn t_rtn_work_collection_defn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rtn_work_collection_submission> t_rtn_work_collection_submission { get; set; }
    }
}
