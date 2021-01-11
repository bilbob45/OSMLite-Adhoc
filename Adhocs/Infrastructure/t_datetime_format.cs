namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_datetime_format
    {
        public int id { get; set; }

        [Required]
        [StringLength(40)]
        public string date_format { get; set; }

        [Required]
        [StringLength(1024)]
        public string description { get; set; }

        [Required]
        [StringLength(10)]
        public string specifier { get; set; }

        [Required]
        [StringLength(1)]
        public string format_type { get; set; }

        public bool is_valid { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }
    }
}
