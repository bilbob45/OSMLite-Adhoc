namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_pnt_penalty_formula
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(40)]
        public string penalty_code { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(120)]
        public string contravention_type { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int formula_order { get; set; }

        [StringLength(40)]
        public string aggr_value { get; set; }

        [StringLength(2)]
        public string object_type { get; set; }

        [StringLength(100)]
        public string object_value { get; set; }

        [StringLength(100)]
        public string object_field { get; set; }

        [StringLength(100)]
        public string row_code { get; set; }

        [StringLength(2048)]
        public string query_expression { get; set; }

        [StringLength(2048)]
        public string query_filter { get; set; }

        public bool is_visible { get; set; }

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

        public virtual t_lkup_contravention_type t_lkup_contravention_type { get; set; }
    }
}
