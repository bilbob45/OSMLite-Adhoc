namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_sct_type_download_count
    {
        [Key]
        public int count_id { get; set; }

        public int? sct_type_id { get; set; }

        [StringLength(128)]
        public string user_name { get; set; }

        [StringLength(40)]
        public string ri_code { get; set; }

        public int? download_count { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }
    }
}
