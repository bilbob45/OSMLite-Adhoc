namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rb_datatype
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_rb_datatype()
        {
            t_rb_metadata = new HashSet<t_rb_metadata>();
            t_rb_metadata1 = new HashSet<t_rb_metadata>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int datatype_id { get; set; }

        [Required]
        [StringLength(20)]
        public string datatype_desc { get; set; }

        [Required]
        [StringLength(15)]
        public string datatype { get; set; }

        public DateTime? created_date { get; set; }

        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime last_modified { get; set; }

        [Required]
        [StringLength(255)]
        public string modified_by { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rb_metadata> t_rb_metadata { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rb_metadata> t_rb_metadata1 { get; set; }
    }
}
