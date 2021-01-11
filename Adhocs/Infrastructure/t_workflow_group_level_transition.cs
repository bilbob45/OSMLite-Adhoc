namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_workflow_group_level_transition
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_workflow_group_level_transition()
        {
            t_workflow_request_action = new HashSet<t_workflow_request_action>();
        }

        [Key]
        public int level_tran_id { get; set; }

        public int grp_lv_id { get; set; }

        public int action_id { get; set; }

        [Required]
        [StringLength(1024)]
        public string description { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }

        public virtual t_workflow_action t_workflow_action { get; set; }

        public virtual t_workflow_group_level t_workflow_group_level { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_workflow_request_action> t_workflow_request_action { get; set; }
    }
}
