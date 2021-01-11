namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_application_permissions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_application_permissions()
        {
            t_application_roles = new HashSet<t_application_roles>();
        }

        [Key]
        [StringLength(450)]
        public string permission_id { get; set; }

        [Required]
        [StringLength(120)]
        public string permission_access { get; set; }

        public string permission_description { get; set; }

        public DateTime created_date { get; set; }

        [StringLength(255)]
        public string created_by { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_application_roles> t_application_roles { get; set; }
    }
}
