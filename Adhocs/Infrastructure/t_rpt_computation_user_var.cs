namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rpt_computation_user_var
    {
        [Key]
        [StringLength(80)]
        public string var_name { get; set; }

        [StringLength(1024)]
        public string var_description { get; set; }

        [Required]
        [StringLength(40)]
        public string var_datatype { get; set; }

        [Required]
        [StringLength(100)]
        public string var_associated_table { get; set; }

        [Required]
        [StringLength(100)]
        public string var_associated_column { get; set; }

        public bool var_need_val_date { get; set; }

        public bool var_need_freq { get; set; }

        public bool var_need_schedule_id { get; set; }

        [StringLength(100)]
        public string var_freq_column { get; set; }

        [StringLength(100)]
        public string var_sched_column { get; set; }

        [Required]
        [StringLength(100)]
        public string var_filter { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }
    }
}
