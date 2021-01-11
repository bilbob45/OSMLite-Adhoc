namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rpt_bank_rating_composite_score
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ri_type_id { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal composite_score_lower_limit { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal composite_score_upper_limit { get; set; }

        [StringLength(256)]
        public string rating { get; set; }

        [StringLength(2)]
        public string risk_category { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime start_validity_date { get; set; }

        public DateTime? end_validity_date { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }
    }
}
