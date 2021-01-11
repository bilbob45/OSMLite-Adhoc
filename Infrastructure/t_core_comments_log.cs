namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_core_comments_log
    {
        [Key]
        public long comment_id { get; set; }

        public int ctype_id { get; set; }

        [Required]
        [StringLength(128)]
        public string object_table_name { get; set; }

        public long? object_unique_id { get; set; }

        [Required]
        [StringLength(40)]
        public string subject { get; set; }

        [Required]
        public string description { get; set; }

        public string remarks { get; set; }

        [StringLength(128)]
        public string attachment_url { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }

        public virtual t_lkup_comments_type t_lkup_comments_type { get; set; }
    }
}
