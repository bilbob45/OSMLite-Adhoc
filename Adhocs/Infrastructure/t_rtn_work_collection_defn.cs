namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rtn_work_collection_defn
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_rtn_work_collection_defn()
        {
            t_pnt_penalty_work_collection_mapping = new HashSet<t_pnt_penalty_work_collection_mapping>();
            t_rtn_returns_work_collection_mapping = new HashSet<t_rtn_returns_work_collection_mapping>();
            t_rtn_work_collection_partial_acc = new HashSet<t_rtn_work_collection_partial_acc>();
            t_rtn_work_collection_submission_partial_acc = new HashSet<t_rtn_work_collection_submission_partial_acc>();
            t_rtn_work_collection_mapping = new HashSet<t_rtn_work_collection_mapping>();
            t_rtn_work_collection_schedule = new HashSet<t_rtn_work_collection_schedule>();
        }

        [Key]
        public int work_collection_id { get; set; }

        [Required]
        [StringLength(12)]
        public string entity { get; set; }

        [Required]
        [StringLength(40)]
        public string work_collection_code { get; set; }

        [Required]
        [StringLength(1024)]
        public string description { get; set; }

        [Required]
        [StringLength(2)]
        public string frequency { get; set; }

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

        public virtual t_entity t_entity { get; set; }

        public virtual t_lkup_frequency t_lkup_frequency { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_pnt_penalty_work_collection_mapping> t_pnt_penalty_work_collection_mapping { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rtn_returns_work_collection_mapping> t_rtn_returns_work_collection_mapping { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rtn_work_collection_partial_acc> t_rtn_work_collection_partial_acc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rtn_work_collection_submission_partial_acc> t_rtn_work_collection_submission_partial_acc { get; set; }

        public virtual t_rtn_work_collection_defn_optn t_rtn_work_collection_defn_optn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rtn_work_collection_mapping> t_rtn_work_collection_mapping { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rtn_work_collection_schedule> t_rtn_work_collection_schedule { get; set; }
    }
}
