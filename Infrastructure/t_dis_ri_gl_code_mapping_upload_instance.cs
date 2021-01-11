namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_dis_ri_gl_code_mapping_upload_instance
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_dis_ri_gl_code_mapping_upload_instance()
        {
            t_dis_ri_gl_code_mapping_upload = new HashSet<t_dis_ri_gl_code_mapping_upload>();
        }

        [Key]
        public int upload_id { get; set; }

        public DateTime upload_date { get; set; }

        public int? ri_id { get; set; }

        [StringLength(40)]
        public string ri_code { get; set; }

        [StringLength(1000)]
        public string comment { get; set; }

        [StringLength(1)]
        public string validation_status { get; set; }

        [Required]
        [StringLength(128)]
        public string upload_filename { get; set; }

        [Required]
        [StringLength(128)]
        public string initiated_by { get; set; }

        public DateTime last_modified { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_dis_ri_gl_code_mapping_upload> t_dis_ri_gl_code_mapping_upload { get; set; }
    }
}
