namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_dis_eod_process_dates
    {
        [Key]
        public int eod_process_id { get; set; }

        [Required]
        [StringLength(40)]
        public string ri_code { get; set; }

        public DateTime balance_date { get; set; }

        public int upload_count { get; set; }

        public int process_flag { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }
    }
}
