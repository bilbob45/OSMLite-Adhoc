namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_core_reporting_institution_history
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ri_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(40)]
        public string ri_code { get; set; }

        [StringLength(20)]
        public string shortname { get; set; }

        [StringLength(256)]
        public string fullname { get; set; }

        [StringLength(300)]
        public string address { get; set; }

        [StringLength(10)]
        public string city { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string lga { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(10)]
        public string state { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(10)]
        public string country_zone { get; set; }

        [StringLength(3)]
        public string country { get; set; }

        [StringLength(40)]
        public string postcode { get; set; }

        [StringLength(20)]
        public string biccode { get; set; }

        [StringLength(20)]
        public string isocode { get; set; }

        [StringLength(30)]
        public string telephone_1 { get; set; }

        [StringLength(30)]
        public string telephone_2 { get; set; }

        [StringLength(30)]
        public string telephone_3 { get; set; }

        [StringLength(30)]
        public string mobile { get; set; }

        [StringLength(30)]
        public string fax { get; set; }

        [StringLength(320)]
        public string email { get; set; }

        [StringLength(3)]
        public string lcl_currency { get; set; }

        [StringLength(3)]
        public string rpt_currency { get; set; }

        [Key]
        [Column(Order = 5)]
        public bool is_active { get; set; }

        public int? admin_user_limit { get; set; }

        public int? users_by_admins_count { get; set; }

        [Key]
        [Column(Order = 6)]
        public DateTime start_validity_date { get; set; }

        public DateTime? end_validity_date { get; set; }

        [StringLength(40)]
        public string char_cust_element1 { get; set; }

        [StringLength(40)]
        public string char_cust_element2 { get; set; }

        [StringLength(40)]
        public string char_cust_element3 { get; set; }

        [StringLength(40)]
        public string char_cust_element4 { get; set; }

        [StringLength(40)]
        public string char_cust_element5 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? num_cust_element1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? num_cust_element2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? num_cust_element3 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? num_cust_element4 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? num_cust_element5 { get; set; }

        [Key]
        [Column(Order = 7)]
        public DateTime created_date { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }
    }
}
