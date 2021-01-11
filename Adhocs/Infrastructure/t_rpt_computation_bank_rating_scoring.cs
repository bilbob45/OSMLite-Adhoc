namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rpt_computation_bank_rating_scoring
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(200)]
        public string bank_rating_code { get; set; }

        public int ri_type_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ri_id { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime rating_date { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? rating_score { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }

        public virtual t_core_reporting_institution t_core_reporting_institution { get; set; }

        public virtual t_core_ri_type t_core_ri_type { get; set; }

        public virtual t_rpt_computation_bank_rating_setup t_rpt_computation_bank_rating_setup { get; set; }
    }
}
