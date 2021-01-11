namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_country_zone
    {
        [Key]
        public int zone_id { get; set; }

        [Required]
        [StringLength(10)]
        public string zone_code { get; set; }

        [Required]
        [StringLength(128)]
        public string zone_name { get; set; }

        [Required]
        [StringLength(3)]
        public string country_code { get; set; }

        public DateTime start_validity_date { get; set; }

        public DateTime end_validity_date { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }
    }
}
