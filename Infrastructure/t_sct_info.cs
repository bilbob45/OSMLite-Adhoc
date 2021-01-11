namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_sct_info
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ritype_id { get; set; }

        [Required]
        [StringLength(11)]
        public string ritype_code { get; set; }

        [Required]
        [StringLength(500)]
        public string ritype_desc { get; set; }

        [StringLength(50)]
        public string sct_version { get; set; }

        public DateTime? created_date { get; set; }

        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime last_modified { get; set; }

        [Required]
        [StringLength(255)]
        public string modified_by { get; set; }
    }
}
