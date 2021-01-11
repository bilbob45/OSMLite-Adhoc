namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_entity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_entity()
        {
            t_rtn_work_collection_defn = new HashSet<t_rtn_work_collection_defn>();
            t_rtn_work_collection = new HashSet<t_rtn_work_collection>();
        }

        [Key]
        [StringLength(12)]
        public string entity { get; set; }

        [Required]
        [StringLength(128)]
        public string name { get; set; }

        [Required]
        [StringLength(1024)]
        public string description { get; set; }

        [Required]
        [StringLength(10)]
        public string calendar { get; set; }

        [Required]
        [StringLength(8)]
        public string account_category { get; set; }

        public DateTime prev_cob_date { get; set; }

        public DateTime cob_date { get; set; }

        public DateTime next_cob_date { get; set; }

        public int current_year { get; set; }

        public int current_period { get; set; }

        public int reporting_year { get; set; }

        public int reporting_period { get; set; }

        public int ed_num_periods_forward { get; set; }

        public int ed_num_periods_back { get; set; }

        public int vd_num_periods_forward { get; set; }

        public int vd_num_periods_back { get; set; }

        [Required]
        [StringLength(3)]
        public string lcl_currency { get; set; }

        [Required]
        [StringLength(3)]
        public string rpt_currency { get; set; }

        [Required]
        [StringLength(40)]
        public string char_cust_element1 { get; set; }

        [Required]
        [StringLength(40)]
        public string char_cust_element2 { get; set; }

        [Required]
        [StringLength(40)]
        public string char_cust_element3 { get; set; }

        [Required]
        [StringLength(40)]
        public string char_cust_element4 { get; set; }

        [Required]
        [StringLength(40)]
        public string char_cust_element5 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal num_cust_element1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal num_cust_element2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal num_cust_element3 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal num_cust_element4 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal num_cust_element5 { get; set; }

        public DateTime last_modified { get; set; }

        [Required]
        [StringLength(255)]
        public string modified_by { get; set; }

        public virtual t_calendar t_calendar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rtn_work_collection_defn> t_rtn_work_collection_defn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rtn_work_collection> t_rtn_work_collection { get; set; }
    }
}
