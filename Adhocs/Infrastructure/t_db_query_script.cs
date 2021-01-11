namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_db_query_script
    {
        [Key]
        public int script_id { get; set; }

        [Required]
        [StringLength(128)]
        public string query_name { get; set; }

        [Required]
        [StringLength(1024)]
        public string query_desc { get; set; }

        [Required]
        public string query_script { get; set; }

        public bool is_public { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }
    }
}
