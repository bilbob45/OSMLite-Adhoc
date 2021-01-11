namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rpt_liq_stress_test_scoring
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(80)]
        public string item_code { get; set; }

        [StringLength(1024)]
        public string item_description { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ri_id { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime valuation_date { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? amount { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }

        public virtual t_core_reporting_institution t_core_reporting_institution { get; set; }
    }
}
