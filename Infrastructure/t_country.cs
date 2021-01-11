namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_country
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(3)]
        public string country_code { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime start_validity_date { get; set; }

        public DateTime end_validity_date { get; set; }

        public int country_iso_number { get; set; }

        [Required]
        [StringLength(4)]
        public string back_office_country_code { get; set; }

        public int back_office_country_number { get; set; }

        [Required]
        [StringLength(128)]
        public string name { get; set; }

        [Required]
        [StringLength(1)]
        public string zone { get; set; }

        [Required]
        [StringLength(3)]
        public string national_currency { get; set; }

        [Required]
        [StringLength(40)]
        public string central_bank_code { get; set; }

        [Required]
        [StringLength(40)]
        public string char_cust_element1 { get; set; }

        [Required]
        [StringLength(40)]
        public string char_cust_element2 { get; set; }

        [Required]
        [StringLength(40)]
        public string char_cust_element3 { get; set; }

        [Required]
        [StringLength(40)]
        public string char_cust_element4 { get; set; }

        [Required]
        [StringLength(40)]
        public string char_cust_element5 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal num_cust_element1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal num_cust_element2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal num_cust_element3 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal num_cust_element4 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal num_cust_element5 { get; set; }

        public DateTime last_modified { get; set; }

        [Required]
        [StringLength(255)]
        public string modified_by { get; set; }
    }
}
