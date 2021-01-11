namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_sct_ri_info
    {
        [Key]
        public long ri_id { get; set; }

        [Required]
        [StringLength(11)]
        public string ri_code { get; set; }

        [StringLength(50)]
        public string ri_name { get; set; }

        public DateTime? created_date { get; set; }

        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime last_modified { get; set; }

        [Required]
        [StringLength(255)]
        public string modified_by { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RiTypeId { get; set; }
    }
}
