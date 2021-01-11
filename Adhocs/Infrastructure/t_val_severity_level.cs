namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_val_severity_level
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_val_severity_level()
        {
            t_rtn_work_collection_submission_validation = new HashSet<t_rtn_work_collection_submission_validation>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int validation_severity_level_id { get; set; }

        [Required]
        [StringLength(128)]
        public string severity_level_name { get; set; }

        [Required]
        [StringLength(1000)]
        public string severity_level_desc { get; set; }

        public int severity_ascending_sequence { get; set; }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rtn_work_collection_submission_validation> t_rtn_work_collection_submission_validation { get; set; }
    }
}
