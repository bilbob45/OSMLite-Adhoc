namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_dis_source_system_query
    {
        [Key]
        [Column(Order = 0)]
        public string source_system_name { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(40)]
        public string source_system_version { get; set; }

        [Required]
        [StringLength(128)]
        public string query_method { get; set; }

        [Required]
        [StringLength(1024)]
        public string query_param { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime start_validity_date { get; set; }

        public DateTime end_validity_date { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }

        public virtual t_dis_source_system t_dis_source_system { get; set; }
    }
}
