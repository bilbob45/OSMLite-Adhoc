namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rpt_liq_stress_test_data_defn
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

        [StringLength(1024)]
        public string item_description { get; set; }

        public DateTime start_validity_date { get; set; }

        public DateTime? end_validity_date { get; set; }

        [StringLength(80)]
        public string font_color { get; set; }

        [StringLength(80)]
        public string font_weight { get; set; }

        [StringLength(80)]
        public string background_color { get; set; }

        public bool user_input_reqd { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }
    }
}
