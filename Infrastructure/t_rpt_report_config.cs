namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rpt_report_config
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int config_id { get; set; }

        [Required]
        [StringLength(255)]
        public string default_value { get; set; }

        [Required]
        [StringLength(255)]
        public string config_value { get; set; }

        public bool enabled { get; set; }

        [Required]
        [StringLength(1000)]
        public string config_value_desc { get; set; }

        public DateTime last_modified { get; set; }

        [Required]
        [StringLength(255)]
        public string modified_by { get; set; }
    }
}
