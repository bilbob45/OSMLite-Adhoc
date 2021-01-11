namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rb_retrun_matrix_status
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_rb_retrun_matrix_status()
        {
            t_rb_returns_matrix = new HashSet<t_rb_returns_matrix>();
            t_rb_returns_matrix1 = new HashSet<t_rb_returns_matrix>();
        }

        [Key]
        [StringLength(50)]
        public string status_code { get; set; }

        [Required]
        [StringLength(128)]
        public string status_name { get; set; }

        [Required]
        [StringLength(1024)]
        public string status_desc { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rb_returns_matrix> t_rb_returns_matrix { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rb_returns_matrix> t_rb_returns_matrix1 { get; set; }
    }
}
