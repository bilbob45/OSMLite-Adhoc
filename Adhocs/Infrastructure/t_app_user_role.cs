namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_app_user_role
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(450)]
        public string user_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(450)]
        public string role_id { get; set; }

        [Required]
        public string Discriminator { get; set; }

        [StringLength(450)]
        public string TApplicationUserId { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }

        public virtual t_application_roles t_application_roles { get; set; }

        public virtual t_application_users t_application_users { get; set; }

        public virtual t_application_users t_application_users1 { get; set; }
    }
}
