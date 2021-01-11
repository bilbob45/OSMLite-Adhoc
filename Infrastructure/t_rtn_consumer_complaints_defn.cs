namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rtn_consumer_complaints_defn
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(80)]
        public string report_code { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(80)]
        public string item_code { get; set; }

        [Required]
        [StringLength(1024)]
        public string item_description { get; set; }

        [StringLength(16)]
        public string shorthand { get; set; }

        [StringLength(512)]
        public string formular { get; set; }

        public string formular_desc { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }
    }
}
