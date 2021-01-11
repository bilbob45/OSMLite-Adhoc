namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rtn_static_returns_content_mapping
    {
        [Key]
        public long returns_content_mapping_id { get; set; }

        [Required]
        [StringLength(40)]
        public string return_code { get; set; }

        [StringLength(255)]
        public string table_name { get; set; }

        [Required]
        [StringLength(40)]
        public string item_code { get; set; }

        [StringLength(4000)]
        public string description_1 { get; set; }

        [Required]
        [StringLength(10)]
        public string mapping_order { get; set; }

        [StringLength(10)]
        public string action { get; set; }

        public long? rel_entity { get; set; }

        [Required]
        [StringLength(40)]
        public string parent { get; set; }

        [StringLength(4000)]
        public string description_2 { get; set; }

        [StringLength(4000)]
        public string description_3 { get; set; }

        [Required]
        [StringLength(5)]
        public string valid_from { get; set; }

        [StringLength(5)]
        public string valid_to { get; set; }

        public bool isactive { get; set; }

        public bool iscomitted { get; set; }

        public bool remap { get; set; }

        public int counts { get; set; }

        public DateTime start_validity_date { get; set; }

        public DateTime? end_validity_date { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }

        public byte is_total { get; set; }
    }
}
