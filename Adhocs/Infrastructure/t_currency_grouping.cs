namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_currency_grouping
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string currency_group { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(3)]
        public string currency { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime start_validity_date { get; set; }

        public DateTime end_validity_date { get; set; }

        public DateTime last_modified { get; set; }

        [Required]
        [StringLength(255)]
        public string modified_by { get; set; }

        public virtual t_currency_group_definition t_currency_group_definition { get; set; }
    }
}
