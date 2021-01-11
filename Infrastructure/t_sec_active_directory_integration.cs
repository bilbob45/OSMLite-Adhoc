namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_sec_active_directory_integration
    {
        [Key]
        public int ads_id { get; set; }

        [Required]
        [StringLength(128)]
        public string domain_name { get; set; }

        [Required]
        [StringLength(128)]
        public string host { get; set; }

        [Required]
        [StringLength(128)]
        public string port_no { get; set; }

        [Required]
        [StringLength(128)]
        public string default_ou { get; set; }

        [Required]
        [StringLength(128)]
        public string default_root_ou { get; set; }

        [Required]
        [StringLength(128)]
        public string service_user { get; set; }

        [Required]
        [StringLength(128)]
        public string service_pwd { get; set; }

        [Required]
        [StringLength(40)]
        public string inst_code { get; set; }

        public bool is_reg { get; set; }

        public DateTime last_modified { get; set; }

        [Required]
        [StringLength(255)]
        public string modified_by { get; set; }
    }
}
