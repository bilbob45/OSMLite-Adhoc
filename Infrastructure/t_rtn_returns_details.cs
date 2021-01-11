namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rtn_returns_details
    {
        [Key]
        public int return_item_id { get; set; }

        [Required]
        [StringLength(40)]
        public string return_code { get; set; }

        [StringLength(40)]
        public string item_code { get; set; }

        public DateTime start_validity_date { get; set; }

        public DateTime? end_validity_date { get; set; }

        [StringLength(1024)]
        public string description_1 { get; set; }

        [StringLength(1024)]
        public string description_2 { get; set; }

        [StringLength(1024)]
        public string description_3 { get; set; }

        public int? order { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }
    }
}
