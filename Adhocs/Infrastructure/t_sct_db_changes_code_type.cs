namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_sct_db_changes_code_type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_sct_db_changes_code_type()
        {
            t_sct_db_changes = new HashSet<t_sct_db_changes>();
            t_sct_db_changes1 = new HashSet<t_sct_db_changes>();
        }

        [Key]
        [StringLength(40)]
        public string type_id { get; set; }

        [Required]
        [StringLength(128)]
        public string type_name { get; set; }

        [Required]
        [StringLength(1024)]
        public string type_desc { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_sct_db_changes> t_sct_db_changes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_sct_db_changes> t_sct_db_changes1 { get; set; }
    }
}
