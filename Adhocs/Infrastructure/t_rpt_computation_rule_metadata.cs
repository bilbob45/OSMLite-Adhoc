namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rpt_computation_rule_metadata
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(40)]
        public string computation_rule { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int version_id { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(40)]
        public string item_code { get; set; }

        [Key]
        [Column(Order = 3)]
        public string template_name { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(10)]
        public string template_row_id { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(10)]
        public string template_column_id { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(40)]
        public string type { get; set; }

        [Required]
        [StringLength(1024)]
        public string formula { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }

        public virtual t_rpt_computation_rule_type t_rpt_computation_rule_type { get; set; }
    }
}
