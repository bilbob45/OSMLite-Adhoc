namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_core_ri_subtype
    {
        [Required]
        [StringLength(40)]
        public string ri_type_code { get; set; }

        [Key]
        [StringLength(40)]
        public string ri_subtype_code { get; set; }

        [Required]
        [StringLength(1024)]
        public string description { get; set; }

        public DateTime start_validity_date { get; set; }

        public DateTime? end_validity_date { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }
    }
}
