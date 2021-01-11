namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_app_user_login
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(450)]
        public string LoginProvider { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(450)]
        public string ProviderKey { get; set; }

        public string ProviderDisplayName { get; set; }

        [Required]
        [StringLength(450)]
        public string user_id { get; set; }

        [Required]
        public string Discriminator { get; set; }

        public virtual t_application_users t_application_users { get; set; }
    }
}
