namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_sec_win_service
    {
        [Key]
        public int sws_id { get; set; }

        [Required]
        [StringLength(128)]
        public string service_name { get; set; }

        [Required]
        [StringLength(128)]
        public string display_name { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }

        public string service_desc { get; set; }
    }
}
