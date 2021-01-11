namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rpt_computation_rule_recalc_trigger
    {
        [Key]
        [Column(Order = 0)]
        public DateTime work_collection_date { get; set; }

        public int? schedule_id { get; set; }

        public int? ri_type_id { get; set; }

        public int process_flag { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }

        public virtual t_core_ri_type t_core_ri_type { get; set; }
    }
}
