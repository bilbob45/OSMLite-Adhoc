namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_core_dept_unit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_core_dept_unit()
        {
            t_core_dept_members = new HashSet<t_core_dept_members>();
            t_rtn_returns_dept_mapping = new HashSet<t_rtn_returns_dept_mapping>();
        }

        [Key]
        public int unit_id { get; set; }

        [Required]
        [StringLength(128)]
        public string unit_name { get; set; }

        [Required]
        [StringLength(128)]
        public string unit_desc { get; set; }

        public byte is_active { get; set; }

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
        public virtual ICollection<t_core_dept_members> t_core_dept_members { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rtn_returns_dept_mapping> t_rtn_returns_dept_mapping { get; set; }
    }
}
