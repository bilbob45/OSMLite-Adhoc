namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_sct_type_download
    {
        [Key]
        public int sct_type_id { get; set; }

        [Required]
        [StringLength(40)]
        public string ri_type_code { get; set; }

        public DateTime start_validity_date { get; set; }

        public DateTime? end_validity_date { get; set; }

        [Required]
        [StringLength(128)]
        public string sct_type_name { get; set; }

        [Required]
        [StringLength(1024)]
        public string description { get; set; }

        [StringLength(128)]
        public string sct_file_name { get; set; }

        [StringLength(128)]
        public string sct_version { get; set; }

        [StringLength(1)]
        public string sct_version_type { get; set; }

        public string sct_features { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }
    }
}
