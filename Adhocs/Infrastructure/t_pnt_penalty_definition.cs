namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_pnt_penalty_definition
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(40)]
        public string penalty_code { get; set; }

        [Required]
        [StringLength(2048)]
        public string penalty_desc { get; set; }

        public int ri_type_id { get; set; }

        [Required]
        [StringLength(2)]
        public string frequency { get; set; }

        [Required]
        [StringLength(4)]
        public string penalty_type { get; set; }

        [Required]
        [StringLength(2)]
        public string penalty_freq { get; set; }

        public int penalty_freq_unit { get; set; }

        public int? delivery_deadline_day { get; set; }

        public int? delivery_deadline_hr { get; set; }

        public int? delivery_deadline_min { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? min_limit_accepted { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? max_limit_accepted { get; set; }

        [Column(TypeName = "numeric")]
        public decimal penalty_value { get; set; }

        public bool penalty_per_unit { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? failed_penalty_value { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime start_validity_date { get; set; }

        public DateTime? end_validity_date { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }

        public virtual t_core_ri_type t_core_ri_type { get; set; }

        public virtual t_lkup_frequency t_lkup_frequency { get; set; }

        public virtual t_lkup_frequency t_lkup_frequency1 { get; set; }

        public virtual t_lkup_penalty_type t_lkup_penalty_type { get; set; }
    }
}
