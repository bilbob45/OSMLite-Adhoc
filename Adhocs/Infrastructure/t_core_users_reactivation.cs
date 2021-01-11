namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_core_users_reactivation
    {
        [Key]
        public int reactivate_id { get; set; }

        public int user_id { get; set; }

        [Required]
        [StringLength(1024)]
        public string reason { get; set; }

        [Required]
        [StringLength(1)]
        public string status { get; set; }

        [Required]
        [StringLength(128)]
        public string requester { get; set; }

        public DateTime status_change_date { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }

        public virtual t_core_users t_core_users { get; set; }
    }
}
