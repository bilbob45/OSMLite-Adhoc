namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_application_roles
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_application_roles()
        {
            t_app_role_claim = new HashSet<t_app_role_claim>();
            t_app_user_role = new HashSet<t_app_user_role>();
            t_application_permissions = new HashSet<t_application_permissions>();
        }

        [Key]
        [StringLength(450)]
        public string role_id { get; set; }

        [Required]
        [StringLength(256)]
        public string role_name { get; set; }

        [StringLength(256)]
        public string role_name_normalised { get; set; }

        public string concurrency_stamp { get; set; }

        public DateTime last_modified { get; set; }

        [Required]
        [StringLength(255)]
        public string modified_by { get; set; }

        public bool is_regulator { get; set; }

        [StringLength(1024)]
        public string role_desc { get; set; }

        public bool? is_department_role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_app_role_claim> t_app_role_claim { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_app_user_role> t_app_user_role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_application_permissions> t_application_permissions { get; set; }
    }
}
