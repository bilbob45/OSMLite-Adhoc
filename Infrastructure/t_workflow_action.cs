namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_workflow_action
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_workflow_action()
        {
            t_workflow_group_level_transition = new HashSet<t_workflow_group_level_transition>();
            t_workflow_request_action = new HashSet<t_workflow_request_action>();
            t_workflow_request_event_history = new HashSet<t_workflow_request_event_history>();
        }

        [Key]
        public int action_id { get; set; }

        public int action_type_id { get; set; }

        public int workflow_id { get; set; }

        [Required]
        [StringLength(40)]
        public string action_code { get; set; }

        [StringLength(128)]
        public string action_name { get; set; }

        [StringLength(1024)]
        public string action_desc { get; set; }

        public bool is_active { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }

        public virtual t_workflow t_workflow { get; set; }

        public virtual t_workflow_action_type t_workflow_action_type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_workflow_group_level_transition> t_workflow_group_level_transition { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_workflow_request_action> t_workflow_request_action { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_workflow_request_event_history> t_workflow_request_event_history { get; set; }
    }
}
