namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rb_assertion_rule_set
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_rb_assertion_rule_set()
        {
            t_rb_assertion_rule = new HashSet<t_rb_assertion_rule>();
        }

        [Key]
        [StringLength(100)]
        public string ruleset_code { get; set; }

        [StringLength(100)]
        public string work_collection { get; set; }

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
        public virtual ICollection<t_rb_assertion_rule> t_rb_assertion_rule { get; set; }
    }
}
