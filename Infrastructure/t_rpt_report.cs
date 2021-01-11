namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rpt_report
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_rpt_report()
        {
            t_rpt_report_group = new HashSet<t_rpt_report_group>();
        }

        [Key]
        public int report_id { get; set; }

        [Required]
        [StringLength(256)]
        public string report_code { get; set; }

        [Required]
        [StringLength(512)]
        public string report_name { get; set; }

        [Required]
        [StringLength(2048)]
        public string report_desc { get; set; }

        public byte is_dashboard_report { get; set; }

        public byte is_editable { get; set; }

        public byte is_active { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rpt_report_group> t_rpt_report_group { get; set; }
    }
}
