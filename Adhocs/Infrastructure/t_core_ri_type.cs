namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_core_ri_type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_core_ri_type()
        {
            t_core_ri_mapping = new HashSet<t_core_ri_mapping>();
            t_rpt_computation_value_table = new HashSet<t_rpt_computation_value_table>();
            t_rpt_computation_bank_rating_setup = new HashSet<t_rpt_computation_bank_rating_setup>();
            t_rpt_computation_rule_recalc_trigger = new HashSet<t_rpt_computation_rule_recalc_trigger>();
            t_rtn_imf_srf_report_code_ri_type_mapping = new HashSet<t_rtn_imf_srf_report_code_ri_type_mapping>();
            t_rtn_work_collection_mapping = new HashSet<t_rtn_work_collection_mapping>();
            t_pnt_penalty_definition = new HashSet<t_pnt_penalty_definition>();
            t_core_ri_type_auth_level = new HashSet<t_core_ri_type_auth_level>();
            t_rpt_contravention_valuation = new HashSet<t_rpt_contravention_valuation>();
            t_rtn_work_collection = new HashSet<t_rtn_work_collection>();
            t_rpt_computation_bank_rating_scoring = new HashSet<t_rpt_computation_bank_rating_scoring>();
        }

        [Key]
        public int ri_type_id { get; set; }

        [Required]
        [StringLength(40)]
        public string ri_type_code { get; set; }

        [Required]
        [StringLength(1024)]
        public string description { get; set; }

        public DateTime start_validity_date { get; set; }

        public DateTime? end_validity_date { get; set; }

        public int? admin_user_limit { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_core_ri_mapping> t_core_ri_mapping { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rpt_computation_value_table> t_rpt_computation_value_table { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rpt_computation_bank_rating_setup> t_rpt_computation_bank_rating_setup { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rpt_computation_rule_recalc_trigger> t_rpt_computation_rule_recalc_trigger { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rtn_imf_srf_report_code_ri_type_mapping> t_rtn_imf_srf_report_code_ri_type_mapping { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rtn_work_collection_mapping> t_rtn_work_collection_mapping { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_pnt_penalty_definition> t_pnt_penalty_definition { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_core_ri_type_auth_level> t_core_ri_type_auth_level { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rpt_contravention_valuation> t_rpt_contravention_valuation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rtn_work_collection> t_rtn_work_collection { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rpt_computation_bank_rating_scoring> t_rpt_computation_bank_rating_scoring { get; set; }
    }
}
