namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rpt_contravention_valuation
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ri_id { get; set; }

        [StringLength(80)]
        public string ri_code { get; set; }

        public int ri_type_id { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime work_collection_date { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(120)]
        public string contravention_type { get; set; }

        [Column(TypeName = "numeric")]
        public decimal amount { get; set; }

        public bool is_visible { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }

        public virtual t_core_reporting_institution t_core_reporting_institution { get; set; }

        public virtual t_core_ri_type t_core_ri_type { get; set; }

        public virtual t_lkup_contravention_type t_lkup_contravention_type { get; set; }
    }
}
