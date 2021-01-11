namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rtn_work_collection_submission_validation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int validation_result_id { get; set; }

        public long submission_id { get; set; }

        public DateTime validation_date { get; set; }

        public int run_id { get; set; }

        public int mex_type { get; set; }

        public int version_id { get; set; }

        [StringLength(128)]
        public string mex_cluster_name { get; set; }

        public int validation_severity_level_id { get; set; }

        [Required]
        [StringLength(1024)]
        public string generic_message { get; set; }

        [Required]
        [StringLength(1000)]
        public string validation_desc { get; set; }

        [Required]
        [StringLength(40)]
        public string return_code { get; set; }

        [Required]
        [StringLength(40)]
        public string row_code { get; set; }

        [Required]
        [StringLength(1024)]
        public string column_list { get; set; }

        public int job_log_id { get; set; }

        public int step_log_id { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }

        public virtual t_val_severity_level t_val_severity_level { get; set; }
    }
}
