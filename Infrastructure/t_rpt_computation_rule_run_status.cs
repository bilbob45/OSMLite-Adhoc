namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rpt_computation_rule_run_status
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long schedule_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int run_id { get; set; }

        public DateTime work_collection_date { get; set; }

        public int ri_type_id { get; set; }

        public int ri_id { get; set; }

        [StringLength(1024)]
        public string execution_comment { get; set; }

        [Required]
        [StringLength(1)]
        public string exec_status { get; set; }

        public string exec_error_msg { get; set; }

        public DateTime execution_date { get; set; }

        [Required]
        [StringLength(255)]
        public string executed_by { get; set; }

        public virtual t_lkup_computation_rule_exec_status t_lkup_computation_rule_exec_status { get; set; }

        public virtual t_rtn_work_collection_schedule t_rtn_work_collection_schedule { get; set; }
    }
}
