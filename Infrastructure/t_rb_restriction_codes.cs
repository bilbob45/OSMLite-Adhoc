namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rb_restriction_codes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_rb_restriction_codes()
        {
            t_rb_restricted_field = new HashSet<t_rb_restricted_field>();
            t_rb_restricted_field1 = new HashSet<t_rb_restricted_field>();
            t_rb_restricted_field2 = new HashSet<t_rb_restricted_field>();
            t_rb_restricted_field3 = new HashSet<t_rb_restricted_field>();
            t_rb_restricted_field4 = new HashSet<t_rb_restricted_field>();
            t_rb_restricted_field5 = new HashSet<t_rb_restricted_field>();
            t_rb_restriction_data = new HashSet<t_rb_restriction_data>();
            t_rb_restriction_data1 = new HashSet<t_rb_restriction_data>();
            t_rb_restriction_data2 = new HashSet<t_rb_restriction_data>();
            t_rb_restriction_data3 = new HashSet<t_rb_restriction_data>();
            t_rb_restriction_data4 = new HashSet<t_rb_restriction_data>();
            t_rb_restriction_data5 = new HashSet<t_rb_restriction_data>();
            t_rb_restriction_data6 = new HashSet<t_rb_restriction_data>();
            t_rb_restriction_data7 = new HashSet<t_rb_restriction_data>();
        }

        [Key]
        [StringLength(40)]
        public string restriction_code { get; set; }

        [Required]
        [StringLength(100)]
        public string restriction_desc { get; set; }

        [Required]
        [StringLength(40)]
        public string restriction_type { get; set; }

        public DateTime created_date { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }

        public DateTime validity_date { get; set; }

        public DateTime? end_validity_date { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rb_restricted_field> t_rb_restricted_field { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rb_restricted_field> t_rb_restricted_field1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rb_restricted_field> t_rb_restricted_field2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rb_restricted_field> t_rb_restricted_field3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rb_restricted_field> t_rb_restricted_field4 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rb_restricted_field> t_rb_restricted_field5 { get; set; }

        public virtual t_rb_restriction_type t_rb_restriction_type { get; set; }

        public virtual t_rb_restriction_type t_rb_restriction_type1 { get; set; }

        public virtual t_rb_restriction_type t_rb_restriction_type2 { get; set; }

        public virtual t_rb_restriction_type t_rb_restriction_type3 { get; set; }

        public virtual t_rb_restriction_type t_rb_restriction_type4 { get; set; }

        public virtual t_rb_restriction_type t_rb_restriction_type5 { get; set; }

        public virtual t_rb_restriction_type t_rb_restriction_type6 { get; set; }

        public virtual t_rb_restriction_type t_rb_restriction_type7 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rb_restriction_data> t_rb_restriction_data { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rb_restriction_data> t_rb_restriction_data1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rb_restriction_data> t_rb_restriction_data2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rb_restriction_data> t_rb_restriction_data3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rb_restriction_data> t_rb_restriction_data4 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rb_restriction_data> t_rb_restriction_data5 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rb_restriction_data> t_rb_restriction_data6 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rb_restriction_data> t_rb_restriction_data7 { get; set; }
    }
}
