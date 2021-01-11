namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_calendar_period
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string calendar { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int year { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int period { get; set; }

        public DateTime period_start_date { get; set; }

        public DateTime period_end_date { get; set; }

        [Required]
        [StringLength(1024)]
        public string description { get; set; }

        public DateTime? last_locked_date { get; set; }

        public DateTime last_modified { get; set; }

        [Required]
        [StringLength(255)]
        public string modified_by { get; set; }

        public virtual t_calendar t_calendar { get; set; }
    }
}
