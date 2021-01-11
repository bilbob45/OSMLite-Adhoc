namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_core_users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_core_users()
        {
            t_core_dept_members = new HashSet<t_core_dept_members>();
            t_core_users_ext = new HashSet<t_core_users_ext>();
            t_core_users_password_hist = new HashSet<t_core_users_password_hist>();
            t_core_users_reactivation = new HashSet<t_core_users_reactivation>();
            t_workflow_group_member = new HashSet<t_workflow_group_member>();
            t_workflow_request = new HashSet<t_workflow_request>();
        }

        [Key]
        public int user_id { get; set; }

        [Required]
        [StringLength(255)]
        public string user_name { get; set; }

        [Required]
        [StringLength(128)]
        public string last_name { get; set; }

        [Required]
        [StringLength(128)]
        public string first_name { get; set; }

        [StringLength(128)]
        public string middle_name { get; set; }

        [Required]
        [StringLength(128)]
        public string app_user_id { get; set; }

        public bool is_regulator { get; set; }

        [Required]
        [StringLength(40)]
        public string user_inst { get; set; }

        [StringLength(320)]
        public string email { get; set; }

        public bool is_active { get; set; }

        public DateTime last_visit_on { get; set; }

        public bool system_person { get; set; }

        [Required]
        [StringLength(8)]
        public string auth_code { get; set; }

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

        public bool sct_download { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_core_dept_members> t_core_dept_members { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_core_users_ext> t_core_users_ext { get; set; }

        public virtual t_core_users_notification_preference t_core_users_notification_preference { get; set; }

        public virtual t_core_users_password t_core_users_password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_core_users_password_hist> t_core_users_password_hist { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_core_users_reactivation> t_core_users_reactivation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_workflow_group_member> t_workflow_group_member { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_workflow_request> t_workflow_request { get; set; }
    }
}
