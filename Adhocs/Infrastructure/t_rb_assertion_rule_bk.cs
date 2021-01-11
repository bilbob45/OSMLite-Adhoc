namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rb_assertion_rule_bk
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string alias { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string ruleset_code { get; set; }

        [StringLength(30)]
        public string rule_type { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(1)]
        public string is_boolean_equation { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(2048)]
        public string assertion_rule { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(2048)]
        public string assertion_messages { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(2048)]
        public string assertion_error { get; set; }

        [StringLength(6)]
        public string connector { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int version_id { get; set; }

        [Key]
        [Column(Order = 7)]
        public DateTime valid_from { get; set; }

        [Key]
        [Column(Order = 8)]
        public bool is_active { get; set; }

        [Key]
        [Column(Order = 9)]
        public DateTime created_date { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }
    }
}
