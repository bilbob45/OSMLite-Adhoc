namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rpt_computation_rule_dependency
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(40)]
        public string computation_rule { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(40)]
        public string computation_rule_dependent { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime start_validity_date { get; set; }

        public DateTime end_validity_date { get; set; }

        public DateTime last_modified { get; set; }

        [Required]
        [StringLength(255)]
        public string modified_by { get; set; }
    }
}
