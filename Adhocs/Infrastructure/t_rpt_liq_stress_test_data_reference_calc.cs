namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rpt_liq_stress_test_data_reference_calc
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(80)]
        public string report_code { get; set; }

        [Required]
        [StringLength(80)]
        public string report_section { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(80)]
        public string item_code { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime start_validity_date { get; set; }

        public DateTime? end_validity_date { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(255)]
        public string column { get; set; }

        public string formula { get; set; }

        public int? level { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }
    }
}
