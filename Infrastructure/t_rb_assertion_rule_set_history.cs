namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rb_assertion_rule_set_history
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string ruleset_code { get; set; }

        [StringLength(100)]
        public string work_collection { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int version_id { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime valid_from { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool is_active { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime created_date { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }
    }
}
