namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rpt_computation_rule_var
    {
        [Key]
        public int rule_code_id { get; set; }

        [StringLength(80)]
        public string rule_code { get; set; }

        public int? ri_type_id { get; set; }

        public int? auth_level_id { get; set; }

        [Required]
        [StringLength(128)]
        public string param { get; set; }

        [StringLength(128)]
        public string param_2 { get; set; }

        [StringLength(1024)]
        public string description_1 { get; set; }

        [StringLength(1024)]
        public string description_2 { get; set; }

        [Required]
        [StringLength(80)]
        public string value { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? divisor { get; set; }

        [StringLength(80)]
        public string lower_limit { get; set; }

        [StringLength(80)]
        public string upper_limit { get; set; }

        public DateTime start_validity_date { get; set; }

        public DateTime end_validity_date { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }
    }
}
