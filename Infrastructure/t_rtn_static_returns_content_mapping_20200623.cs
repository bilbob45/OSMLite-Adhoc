namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rtn_static_returns_content_mapping_20200623
    {
        [Key]
        [Column(Order = 0)]
        public long returns_content_mapping_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(40)]
        public string return_code { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(40)]
        public string item_code { get; set; }

        [StringLength(4000)]
        public string description_1 { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(10)]
        public string mapping_order { get; set; }

        [StringLength(10)]
        public string action { get; set; }

        public long? rel_entity { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(40)]
        public string parent { get; set; }

        [StringLength(4000)]
        public string description_2 { get; set; }

        [StringLength(4000)]
        public string description_3 { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(5)]
        public string valid_from { get; set; }

        [StringLength(5)]
        public string valid_to { get; set; }

        [Key]
        [Column(Order = 6)]
        public bool isactive { get; set; }

        [Key]
        [Column(Order = 7)]
        public bool iscomitted { get; set; }

        [Key]
        [Column(Order = 8)]
        public bool remap { get; set; }

        [Key]
        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int counts { get; set; }

        [Key]
        [Column(Order = 10)]
        public DateTime start_validity_date { get; set; }

        public DateTime? end_validity_date { get; set; }

        [Key]
        [Column(Order = 11)]
        public DateTime created_date { get; set; }

        [Key]
        [Column(Order = 12)]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }
    }
}
