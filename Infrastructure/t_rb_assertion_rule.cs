namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rb_assertion_rule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_rb_assertion_rule()
        {
            t_rb_assertion_operand = new HashSet<t_rb_assertion_operand>();
        }

        [Key]
        [StringLength(100)]
        public string alias { get; set; }

        [Required]
        [StringLength(100)]
        public string ruleset_code { get; set; }

        [StringLength(40)]
        public string return_code { get; set; }

        [StringLength(40)]
        public string return_dependency_code { get; set; }

        [StringLength(30)]
        public string rule_type { get; set; }

        [Required]
        [StringLength(1)]
        public string is_boolean_equation { get; set; }

        [Required]
        [StringLength(4000)]
        public string assertion_rule { get; set; }

        [Required]
        [StringLength(4000)]
        public string assertion_messages { get; set; }

        [Required]
        [StringLength(4000)]
        public string assertion_error { get; set; }

        [StringLength(6)]
        public string connector { get; set; }

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
        public virtual ICollection<t_rb_assertion_operand> t_rb_assertion_operand { get; set; }

        public virtual t_rb_assertion_rule_set t_rb_assertion_rule_set { get; set; }
    }
}
