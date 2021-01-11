namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_db_name_defn
    {
        [Key]
        public string db_name { get; set; }

        [Required]
        [StringLength(1024)]
        public string db_desc { get; set; }

        [Required]
        [StringLength(1024)]
        public string db_file_path { get; set; }

        [Required]
        [StringLength(1024)]
        public string db_log_path { get; set; }

        public bool is_deleted { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }
    }
}
