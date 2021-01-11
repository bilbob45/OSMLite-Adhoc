namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_calendar_date
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string calendar { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime date { get; set; }

        public bool is_working_day { get; set; }

        public DateTime last_modified { get; set; }

        [Required]
        [StringLength(255)]
        public string modified_by { get; set; }

        public virtual t_calendar t_calendar { get; set; }
    }
}
