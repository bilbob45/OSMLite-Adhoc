namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_core_consumer_complaints_ref_upload
    {
        [Key]
        public long upload_id { get; set; }

        [Required]
        [StringLength(40)]
        public string return_code { get; set; }

        [Required]
        [StringLength(40)]
        public string ri_code { get; set; }

        public int return_id { get; set; }

        [Required]
        [StringLength(40)]
        public string complaint_reference_no { get; set; }

        [Required]
        [StringLength(128)]
        public string file_name { get; set; }

        [Required]
        [StringLength(128)]
        public string file_name_ext { get; set; }

        [Required]
        [StringLength(128)]
        public string file_dest_name { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }
    }
}
