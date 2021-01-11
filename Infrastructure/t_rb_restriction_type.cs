namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rb_restriction_type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_rb_restriction_type()
        {
            t_rb_restriction_codes = new HashSet<t_rb_restriction_codes>();
            t_rb_restriction_codes1 = new HashSet<t_rb_restriction_codes>();
            t_rb_restriction_codes2 = new HashSet<t_rb_restriction_codes>();
            t_rb_restriction_codes3 = new HashSet<t_rb_restriction_codes>();
            t_rb_restriction_codes4 = new HashSet<t_rb_restriction_codes>();
            t_rb_restriction_codes5 = new HashSet<t_rb_restriction_codes>();
            t_rb_restriction_codes6 = new HashSet<t_rb_restriction_codes>();
            t_rb_restriction_codes7 = new HashSet<t_rb_restriction_codes>();
        }

        [Key]
        [StringLength(40)]
        public string restriction_type { get; set; }

        [Required]
        [StringLength(40)]
        public string restriction_type_desc { get; set; }

        [Required]
        [StringLength(1000)]
        public string item_description { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rb_restriction_codes> t_rb_restriction_codes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rb_restriction_codes> t_rb_restriction_codes1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rb_restriction_codes> t_rb_restriction_codes2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rb_restriction_codes> t_rb_restriction_codes3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rb_restriction_codes> t_rb_restriction_codes4 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rb_restriction_codes> t_rb_restriction_codes5 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rb_restriction_codes> t_rb_restriction_codes6 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rb_restriction_codes> t_rb_restriction_codes7 { get; set; }
    }
}
