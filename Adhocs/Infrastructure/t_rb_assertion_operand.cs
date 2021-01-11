namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rb_assertion_operand
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_rb_assertion_operand()
        {
            t_rb_assertion_complex_operand = new HashSet<t_rb_assertion_complex_operand>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long operand_id { get; set; }

        [Required]
        [StringLength(100)]
        public string alias { get; set; }

        public int order_number { get; set; }

        [StringLength(100)]
        public string item_code { get; set; }

        [StringLength(200)]
        public string columnname { get; set; }

        [Required]
        [StringLength(1)]
        public string is_boolean_equation { get; set; }

        [Required]
        [StringLength(1)]
        public string is_boolean_lhs { get; set; }

        [Required]
        [StringLength(1)]
        public string is_boolean_rhs { get; set; }

        [StringLength(6)]
        public string init_operator_type { get; set; }

        [StringLength(6)]
        public string folowing_operator_type { get; set; }

        [StringLength(6)]
        public string complex_operator_type { get; set; }

        [StringLength(1024)]
        public string place_holder { get; set; }

        [Required]
        [StringLength(1)]
        public string is_boolean_complex { get; set; }

        public int version_id { get; set; }

        public DateTime valid_from { get; set; }

        public bool is_active { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rb_assertion_complex_operand> t_rb_assertion_complex_operand { get; set; }

        public virtual t_rb_assertion_rule t_rb_assertion_rule { get; set; }
    }
}
