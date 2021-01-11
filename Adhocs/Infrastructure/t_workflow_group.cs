namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_workflow_group
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_workflow_group()
        {
            t_workflow_group_member = new HashSet<t_workflow_group_member>();
            t_workflow_group_level = new HashSet<t_workflow_group_level>();
            t_workflow_request = new HashSet<t_workflow_request>();
            t_workflow_request_event_history = new HashSet<t_workflow_request_event_history>();
            t_workflow_request_action = new HashSet<t_workflow_request_action>();
            t_workflow_request_event_history1 = new HashSet<t_workflow_request_event_history>();
        }

        [Key]
        public int group_id { get; set; }

        [Required]
        [StringLength(128)]
        public string group_name { get; set; }

        [Required]
        [StringLength(1024)]
        public string group_desc { get; set; }

        [Required]
        [StringLength(320)]
        public string group_email { get; set; }

        [StringLength(40)]
        public string inst_code { get; set; }

        public bool is_active { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_workflow_group_member> t_workflow_group_member { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_workflow_group_level> t_workflow_group_level { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_workflow_request> t_workflow_request { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_workflow_request_event_history> t_workflow_request_event_history { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_workflow_request_action> t_workflow_request_action { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_workflow_request_event_history> t_workflow_request_event_history1 { get; set; }
    }
}
