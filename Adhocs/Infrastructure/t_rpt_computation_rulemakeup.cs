namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rpt_computation_rulemakeup
    {
        [Key]
        public int rule_makeup_ID { get; set; }

        public int ruleBase_ID { get; set; }

        [Required]
        [StringLength(40)]
        public string member_type { get; set; }

        [Required]
        [StringLength(40)]
        public string rule_order { get; set; }

        [StringLength(40)]
        public string return_code { get; set; }

        [StringLength(40)]
        public string item_code { get; set; }

        [StringLength(50)]
        public string column_code { get; set; }

        [StringLength(8000)]
        public string value { get; set; }

        [StringLength(200)]
        public string rule_value { get; set; }

        [Column("operator")]
        [StringLength(10)]
        public string _operator { get; set; }

        public DateTime last_modified { get; set; }

        [Required]
        [StringLength(255)]
        public string modified_by { get; set; }

        public int? rule_row { get; set; }

        public int? rule_column { get; set; }

        [StringLength(20)]
        public string trend { get; set; }

        public virtual t_rpt_computation_rulebase t_rpt_computation_rulebase { get; set; }

        public virtual t_rpt_computation_rulebase t_rpt_computation_rulebase1 { get; set; }
    }
}
