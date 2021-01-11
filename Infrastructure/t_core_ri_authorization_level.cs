namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_core_ri_authorization_level
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_core_ri_authorization_level()
        {
            t_core_ri_mapping = new HashSet<t_core_ri_mapping>();
            t_core_ri_type_auth_level = new HashSet<t_core_ri_type_auth_level>();
        }

        [Key]
        public int auth_level_id { get; set; }

        [Required]
        [StringLength(128)]
        public string auth_level { get; set; }

        [Required]
        [StringLength(1024)]
        public string description { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? capitalization { get; set; }

        public byte is_active { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_core_ri_mapping> t_core_ri_mapping { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_core_ri_type_auth_level> t_core_ri_type_auth_level { get; set; }
    }
}
