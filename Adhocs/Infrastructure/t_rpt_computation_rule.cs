namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rpt_computation_rule
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(40)]
        public string computation_rule { get; set; }

        [StringLength(1024)]
        public string description { get; set; }

        public int mex_type { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int version_id { get; set; }

        [Required]
        [StringLength(1)]
        public string trigger_recalc { get; set; }

        [Required]
        [StringLength(1)]
        public string global_rule { get; set; }

        public DateTime valid_from { get; set; }

        public bool is_active { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }
    }
}
