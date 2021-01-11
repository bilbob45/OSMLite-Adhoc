namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_dis_ri_eod_date
    {
        [Key]
        [StringLength(40)]
        public string ri_code { get; set; }

        public DateTime current_source_system_date { get; set; }

        [Required]
        [StringLength(20)]
        public string business_month_convention_code { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }

        public virtual t_lkup_business_month_convention t_lkup_business_month_convention { get; set; }
    }
}
