namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_time_unit
    {
        [Key]
        [StringLength(2)]
        public string time_unit { get; set; }

        [Required]
        [StringLength(128)]
        public string time_unit_name { get; set; }

        [Required]
        [StringLength(1000)]
        public string time_unit_desc { get; set; }

        public int time_unit_in_days { get; set; }

        public DateTime last_modified { get; set; }

        [Required]
        [StringLength(255)]
        public string modified_by { get; set; }
    }
}
