namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_currency_rate
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string rate_type { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(3)]
        public string from_currency { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(3)]
        public string to_currency { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime rate_date { get; set; }

        [Column(TypeName = "numeric")]
        public decimal rate { get; set; }

        [Required]
        [StringLength(1)]
        public string multiply_divide_ind { get; set; }

        public DateTime last_modified { get; set; }

        [Required]
        [StringLength(255)]
        public string modified_by { get; set; }

        public virtual t_currency_rate_type t_currency_rate_type { get; set; }
    }
}
