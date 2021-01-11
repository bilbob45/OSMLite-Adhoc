namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rb_restricted_field_bkup
    {
        [Key]
        [Column(Order = 0)]
        public int restricted_field_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(40)]
        public string return_code { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(200)]
        public string return_field { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(40)]
        public string restriction_code { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(5)]
        public string version_code { get; set; }

        [Key]
        [Column(Order = 5)]
        public DateTime created_date { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }
    }
}
