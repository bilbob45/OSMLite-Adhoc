namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rtn_detailed_imf_srf_pmb
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ri_id { get; set; }

        [StringLength(40)]
        public string ri_code { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime report_date { get; set; }

        public DateTime work_collection_date { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(100)]
        public string item_code { get; set; }

        [StringLength(2048)]
        public string item_description { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? den_lcy_amt { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? den_fcy_amt { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? total { get; set; }

        public long schedule_id { get; set; }

        [Required]
        [StringLength(2)]
        public string return_status { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }

        public virtual t_core_reporting_institution t_core_reporting_institution { get; set; }

        public virtual t_rtn_work_collection_schedule t_rtn_work_collection_schedule { get; set; }
    }
}
