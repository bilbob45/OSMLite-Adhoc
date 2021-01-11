namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rb_extraction_info_mig
    {
        [Key]
        public long extr_id { get; set; }

        [Required]
        [StringLength(11)]
        public string template_code { get; set; }

        [Required]
        [StringLength(11)]
        public string template_name { get; set; }

        public int template_type { get; set; }

        public DateTime? created_date { get; set; }

        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime last_modified { get; set; }

        [Required]
        [StringLength(255)]
        public string modified_by { get; set; }
    }
}
