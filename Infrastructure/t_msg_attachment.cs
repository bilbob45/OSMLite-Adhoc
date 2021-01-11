namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_msg_attachment
    {
        [Key]
        public long attachment_id { get; set; }

        public long msg_hist_id { get; set; }

        [StringLength(128)]
        public string attachment_name { get; set; }

        [Required]
        [StringLength(128)]
        public string attachment_file { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }

        public virtual t_msg_history t_msg_history { get; set; }
    }
}
