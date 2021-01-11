namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_core_reporting_institution
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_core_reporting_institution()
        {
            t_rpt_computation_value = new HashSet<t_rpt_computation_value>();
            t_rpt_computation_value_cmb000 = new HashSet<t_rpt_computation_value_cmb000>();
            t_rpt_computation_value_simple = new HashSet<t_rpt_computation_value_simple>();
            t_rpt_contravention_valuation = new HashSet<t_rpt_contravention_valuation>();
            t_rpt_liq_stress_test_scoring = new HashSet<t_rpt_liq_stress_test_scoring>();
            t_rpt_computation_bank_rating_scoring = new HashSet<t_rpt_computation_bank_rating_scoring>();
            t_rtn_detailed_imf_srf_cmb = new HashSet<t_rtn_detailed_imf_srf_cmb>();
            t_rtn_detailed_imf_srf_ins = new HashSet<t_rtn_detailed_imf_srf_ins>();
            t_rtn_detailed_imf_srf_mfb = new HashSet<t_rtn_detailed_imf_srf_mfb>();
            t_rtn_detailed_imf_srf_nib = new HashSet<t_rtn_detailed_imf_srf_nib>();
            t_rtn_detailed_imf_srf_pen = new HashSet<t_rtn_detailed_imf_srf_pen>();
            t_rtn_detailed_imf_srf_pmb = new HashSet<t_rtn_detailed_imf_srf_pmb>();
            t_core_ri_mapping = new HashSet<t_core_ri_mapping>();
            t_rtn_work_collection_schedule = new HashSet<t_rtn_work_collection_schedule>();
        }

        [Key]
        public int ri_id { get; set; }

        [Required]
        [StringLength(40)]
        public string ri_code { get; set; }

        [Required]
        [StringLength(20)]
        public string shortname { get; set; }

        [Required]
        [StringLength(256)]
        public string fullname { get; set; }

        [StringLength(300)]
        public string address { get; set; }

        [Required]
        [StringLength(10)]
        public string city { get; set; }

        [Required]
        [StringLength(10)]
        public string lga { get; set; }

        [Required]
        [StringLength(10)]
        public string state { get; set; }

        [Required]
        [StringLength(10)]
        public string country_zone { get; set; }

        [StringLength(3)]
        public string country { get; set; }

        [StringLength(40)]
        public string postcode { get; set; }

        [StringLength(20)]
        public string biccode { get; set; }

        [StringLength(20)]
        public string isocode { get; set; }

        [StringLength(30)]
        public string telephone_1 { get; set; }

        [StringLength(30)]
        public string telephone_2 { get; set; }

        [StringLength(30)]
        public string telephone_3 { get; set; }

        [StringLength(30)]
        public string mobile { get; set; }

        [StringLength(30)]
        public string fax { get; set; }

        [StringLength(320)]
        public string email { get; set; }

        [StringLength(3)]
        public string lcl_currency { get; set; }

        [StringLength(3)]
        public string rpt_currency { get; set; }

        public bool is_active { get; set; }

        public int? admin_user_limit { get; set; }

        public int? users_by_admins_count { get; set; }

        public DateTime start_validity_date { get; set; }

        public DateTime? end_validity_date { get; set; }

        [StringLength(40)]
        public string char_cust_element1 { get; set; }

        [StringLength(40)]
        public string char_cust_element2 { get; set; }

        [StringLength(40)]
        public string char_cust_element3 { get; set; }

        [StringLength(40)]
        public string char_cust_element4 { get; set; }

        [StringLength(40)]
        public string char_cust_element5 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? num_cust_element1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? num_cust_element2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? num_cust_element3 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? num_cust_element4 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? num_cust_element5 { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rpt_computation_value> t_rpt_computation_value { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rpt_computation_value_cmb000> t_rpt_computation_value_cmb000 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rpt_computation_value_simple> t_rpt_computation_value_simple { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rpt_contravention_valuation> t_rpt_contravention_valuation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rpt_liq_stress_test_scoring> t_rpt_liq_stress_test_scoring { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rpt_computation_bank_rating_scoring> t_rpt_computation_bank_rating_scoring { get; set; }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_core_ri_mapping> t_core_ri_mapping { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rtn_work_collection_schedule> t_rtn_work_collection_schedule { get; set; }
    }
}
