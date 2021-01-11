namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_workflow_request
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_workflow_request()
        {
            t_workflow_request_action = new HashSet<t_workflow_request_action>();
            t_workflow_request_file = new HashSet<t_workflow_request_file>();
            t_workflow_request_event_history = new HashSet<t_workflow_request_event_history>();
        }

        [Key]
        public long request_id { get; set; }

        public int workflow_id { get; set; }

        [Required]
        [StringLength(128)]
        public string request_title { get; set; }

        [Required]
        [StringLength(1024)]
        public string request_name { get; set; }

        public string request_desc { get; set; }

        public DateTime? requested_date { get; set; }

        public DateTime? deadline_date { get; set; }

        public int current_state_type { get; set; }

        public int current_group { get; set; }

        public int current_level { get; set; }

        public int? prev_group { get; set; }

        public int? prev_level { get; set; }

        public int? next_group { get; set; }

        public int? next_level { get; set; }

        public DateTime date_level_change { get; set; }

        public int request_maker_id { get; set; }

        [Required]
        [StringLength(40)]
        public string request_institution_code { get; set; }

        [Required]
        [StringLength(40)]
        public string ri_institution_code { get; set; }

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

        public virtual t_core_users t_core_users { get; set; }

        public virtual t_workflow t_workflow { get; set; }

        public virtual t_workflow_group t_workflow_group { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_workflow_request_action> t_workflow_request_action { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_workflow_request_file> t_workflow_request_file { get; set; }

        public virtual t_workflow_request_ose_ext t_workflow_request_ose_ext { get; set; }

        public virtual t_workflow_state_type t_workflow_state_type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_workflow_request_event_history> t_workflow_request_event_history { get; set; }
    }
}
