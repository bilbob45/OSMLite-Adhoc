namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_fsp_rpt_rs_object_type
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(1)]
        public string object_type { get; set; }

        [Key]
        [Column(Order = 1)]
        public string object_type_name { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime last_modified { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(255)]
        public string modified_by { get; set; }
    }
}
