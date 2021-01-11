namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rtn_returns
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_rtn_returns()
        {
            t_ose_exam_returns_mapping = new HashSet<t_ose_exam_returns_mapping>();
            t_rtn_returns_dept_mapping = new HashSet<t_rtn_returns_dept_mapping>();
            t_rtn_returns_work_collection_mapping = new HashSet<t_rtn_returns_work_collection_mapping>();
        }

        [Key]
        [StringLength(40)]
        public string return_code { get; set; }

        [StringLength(1024)]
        public string description { get; set; }

        public DateTime start_validity_date { get; set; }

        public DateTime? end_validity_date { get; set; }

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

        public virtual t_lkup_frequency t_lkup_frequency { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_ose_exam_returns_mapping> t_ose_exam_returns_mapping { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rtn_returns_dept_mapping> t_rtn_returns_dept_mapping { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rtn_returns_work_collection_mapping> t_rtn_returns_work_collection_mapping { get; set; }
    }
}
