namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_calendar_detail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int calendar_detail_id { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string calendar { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime date { get; set; }

        [Required]
        [StringLength(128)]
        public string weekday_name { get; set; }

        public short month { get; set; }

        [Required]
        [StringLength(128)]
        public string month_name { get; set; }

        public int year { get; set; }

        public short quarter { get; set; }

        [Required]
        [StringLength(128)]
        public string quarter_name { get; set; }

        public int accounting_period { get; set; }

        public int accounting_period_days { get; set; }

        [Required]
        [StringLength(128)]
        public string accounting_period_name { get; set; }

        public DateTime accounting_period_start_date { get; set; }

        public DateTime accounting_period_end_date { get; set; }

        public int day_of_accounting_period { get; set; }

        public int accounting_year { get; set; }

        public DateTime accounting_year_start_date { get; set; }

        public DateTime accounting_year_end_date { get; set; }

        public int first_accounting_period { get; set; }

        public int last_accounting_period { get; set; }

        public byte is_working_day { get; set; }

        public byte is_locked { get; set; }

        public DateTime? previous_cob_date { get; set; }

        public DateTime? next_cob_date { get; set; }

        public DateTime? first_cob_date_of_accounting_period { get; set; }

        public DateTime? last_cob_date_of_accounting_period { get; set; }

        public DateTime? first_cob_date_of_accounting_year { get; set; }

        public DateTime? last_cob_date_of_accounting_year { get; set; }

        public DateTime? first_cob_date_of_quarter { get; set; }

        public DateTime? last_cob_date_of_quarter { get; set; }

        public DateTime? closest_past_cob_date { get; set; }

        public DateTime? closest_future_cob_date { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime day_count_convention_calendar { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? day_count_convention_following { get; set; }

        public DateTime? day_count_convention_following_modified { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? day_count_convention_preceding { get; set; }

        public DateTime? day_count_convention_preceding_modified { get; set; }

        public DateTime last_modified { get; set; }

        [Required]
        [StringLength(255)]
        public string modified_by { get; set; }

        public virtual t_calendar t_calendar { get; set; }
    }
}
