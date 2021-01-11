namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_dis_gl_type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_dis_gl_type()
        {
            t_dis_source_system_gl_type_mapping = new HashSet<t_dis_source_system_gl_type_mapping>();
        }

        [Key]
        [StringLength(10)]
        public string gl_type { get; set; }

        [Required]
        [StringLength(128)]
        public string gl_type_name { get; set; }

        public DateTime last_modified { get; set; }

        [Required]
        [StringLength(255)]
        public string modified_by { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_dis_source_system_gl_type_mapping> t_dis_source_system_gl_type_mapping { get; set; }
    }
}
