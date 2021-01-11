namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_calendar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_calendar()
        {
            t_calendar_date = new HashSet<t_calendar_date>();
            t_calendar_detail = new HashSet<t_calendar_detail>();
            t_calendar_period = new HashSet<t_calendar_period>();
            t_entity = new HashSet<t_entity>();
        }

        [Key]
        [StringLength(10)]
        public string calendar { get; set; }

        [Required]
        [StringLength(1024)]
        public string description { get; set; }

        public DateTime calendar_start_date { get; set; }

        public DateTime calendar_end_date { get; set; }

        public bool is_valid { get; set; }

        public byte is_monday_workday { get; set; }

        public byte is_tuesday_workday { get; set; }

        public byte is_wednesday_workday { get; set; }

        public byte is_thursday_workday { get; set; }

        public byte is_friday_workday { get; set; }

        public byte is_saturday_workday { get; set; }

        public byte is_sunday_workday { get; set; }

        public DateTime last_detail_update { get; set; }

        public DateTime last_modified { get; set; }

        [Required]
        [StringLength(255)]
        public string modified_by { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_calendar_date> t_calendar_date { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_calendar_detail> t_calendar_detail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_calendar_period> t_calendar_period { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_entity> t_entity { get; set; }
    }
}
