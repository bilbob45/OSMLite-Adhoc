namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_workflow_state_type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_workflow_state_type()
        {
            t_workflow_request = new HashSet<t_workflow_request>();
            t_workflow_request_action = new HashSet<t_workflow_request_action>();
            t_workflow_request_event_history = new HashSet<t_workflow_request_event_history>();
            t_workflow_request_file = new HashSet<t_workflow_request_file>();
        }

        [Key]
        public int state_type_id { get; set; }

        [Required]
        [StringLength(128)]
        public string state_type_name { get; set; }

        [StringLength(1024)]
        public string state_type_desc { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_workflow_request> t_workflow_request { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_workflow_request_action> t_workflow_request_action { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_workflow_request_event_history> t_workflow_request_event_history { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_workflow_request_file> t_workflow_request_file { get; set; }
    }
}
