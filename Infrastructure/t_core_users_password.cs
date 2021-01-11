namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_core_users_password
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int user_id { get; set; }

        [Required]
        public string pwd_encrypt { get; set; }

        public DateTime? pwd_changed_date { get; set; }

        public DateTime? pwd_expiry_date { get; set; }

        public DateTime? last_login { get; set; }

        public int cumulative_logins { get; set; }

        public int successful_logins { get; set; }

        public int invalid_logins { get; set; }

        public bool force_pwd_change { get; set; }

        public bool locked_out { get; set; }

        public DateTime? lockout_date { get; set; }

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
