namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_crsb_bic_codes
    {
        [Key]
        [StringLength(40)]
        public string bic_code { get; set; }

        [Required]
        [StringLength(128)]
        public string institution_name { get; set; }

        [Required]
        [StringLength(300)]
        public string bank_address_1 { get; set; }

        [Required]
        [StringLength(300)]
        public string bank_address_2 { get; set; }

        [Required]
        [StringLength(300)]
        public string bank_address_3 { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }
    }
}
