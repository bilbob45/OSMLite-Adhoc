namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_workflow_request_event_history
    {
        [Key]
        public long event_history_id { get; set; }

        public int workflow_id { get; set; }

        public long request_id { get; set; }

        public int reviewer_id { get; set; }

        public int prev_group_id { get; set; }

        public int current_group_id { get; set; }

        public int current_level { get; set; }

        public int action_id { get; set; }

        public int state_type_id { get; set; }

        public string comment { get; set; }

        public int restrict_comment_level { get; set; }

        public DateTime date_reviewed { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }

        public virtual t_workflow t_workflow { get; set; }

        public virtual t_workflow_action t_workflow_action { get; set; }

        public virtual t_workflow_group t_workflow_group { get; set; }

        public virtual t_workflow_group t_workflow_group1 { get; set; }

        public virtual t_workflow_request t_workflow_request { get; set; }

        public virtual t_workflow_state_type t_workflow_state_type { get; set; }
    }
}
