namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_dis_source_system_gl_type_mapping
    {
        [Key]
        [Column(Order = 0)]
        public string source_system_name { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string source_gl_type { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string gl_type { get; set; }

        [Required]
        [StringLength(1)]
        public string natural_dr_cr_flag_bal { get; set; }

        public DateTime start_validity_date { get; set; }

        public DateTime end_validity_date { get; set; }

        public DateTime last_modified { get; set; }

        [Required]
        [StringLength(255)]
        public string modified_by { get; set; }

        public virtual t_dis_gl_type t_dis_gl_type { get; set; }

        public virtual t_dis_source_system t_dis_source_system { get; set; }
    }
}
