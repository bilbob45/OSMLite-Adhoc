namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_dis_source_system
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_dis_source_system()
        {
            t_dis_ri_conn_param = new HashSet<t_dis_ri_conn_param>();
            t_dis_source_system_query = new HashSet<t_dis_source_system_query>();
            t_dis_source_system_gl_type_mapping = new HashSet<t_dis_source_system_gl_type_mapping>();
        }

        [Key]
        public string source_system_name { get; set; }

        [Required]
        [StringLength(1000)]
        public string source_system_desc { get; set; }

        public DateTime last_modified { get; set; }

        [Required]
        [StringLength(255)]
        public string modified_by { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_dis_ri_conn_param> t_dis_ri_conn_param { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_dis_source_system_query> t_dis_source_system_query { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_dis_source_system_gl_type_mapping> t_dis_source_system_gl_type_mapping { get; set; }
    }
}
