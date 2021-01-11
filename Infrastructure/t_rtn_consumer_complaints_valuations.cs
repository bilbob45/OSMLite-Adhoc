namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rtn_consumer_complaints_valuations
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(80)]
        public string report_code { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(80)]
        public string item_code { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ri_id { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime report_date { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? amount { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }
    }
}
