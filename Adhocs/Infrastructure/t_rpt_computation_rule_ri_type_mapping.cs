namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rpt_computation_rule_ri_type_mapping
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(40)]
        public string computation_rule { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(40)]
        public string ri_type_code { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }
    }
}
