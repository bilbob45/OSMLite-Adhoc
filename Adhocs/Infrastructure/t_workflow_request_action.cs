namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_workflow_request_action
    {
        [Key]
        public long req_action_id { get; set; }

        public long request_id { get; set; }

        public int workflow_id { get; set; }

        public int action_id { get; set; }

        public int state_type_id { get; set; }

        public int level_tran_id { get; set; }

        public int group_id { get; set; }

        public int action_level { get; set; }

        public bool is_active { get; set; }

        public bool is_executed { get; set; }

        public bool is_completed { get; set; }

        [StringLength(40)]
        public string char_cust_element1 { get; set; }

        [StringLength(40)]
        public string char_cust_element2 { get; set; }

        [StringLength(40)]
        public string char_cust_element3 { get; set; }

        [StringLength(40)]
        public string char_cust_element4 { get; set; }

        [StringLength(40)]
        public string char_cust_element5 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? num_cust_element1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? num_cust_element2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? num_cust_element3 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? num_cust_element4 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? num_cust_element5 { get; set; }

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

        public virtual t_workflow_group_level_transition t_workflow_group_level_transition { get; set; }

        public virtual t_workflow_request t_workflow_request { get; set; }

        public virtual t_workflow_state_type t_workflow_state_type { get; set; }
    }
}
