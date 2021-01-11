namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_crsb_msg_source
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_crsb_msg_source()
        {
            t_crsb_msg_incoming = new HashSet<t_crsb_msg_incoming>();
            t_crsb_msg_outgoing = new HashSet<t_crsb_msg_outgoing>();
        }

        [Key]
        [StringLength(40)]
        public string source { get; set; }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_crsb_msg_incoming> t_crsb_msg_incoming { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_crsb_msg_outgoing> t_crsb_msg_outgoing { get; set; }
    }
}
