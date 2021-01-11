namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_ose_questn
    {
        [Key]
        public int questn_id { get; set; }

        [Required]
        [StringLength(128)]
        public string questn_name { get; set; }

        [Required]
        [StringLength(1024)]
        public string questn_desc { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }
    }
}
