namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rb_rest_bvn_tin_mapping
    {
        [Key]
        public int rest_bvn_tin_id { get; set; }

        [Required]
        [StringLength(40)]
        public string return_code { get; set; }

        [Required]
        [StringLength(200)]
        public string bvn_field { get; set; }

        [Required]
        [StringLength(200)]
        public string tin_field { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }
    }
}
