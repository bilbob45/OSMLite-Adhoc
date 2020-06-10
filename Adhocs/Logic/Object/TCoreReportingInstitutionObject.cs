using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Adhocs.Logic.Objects
{
    public class TCoreReportingInstitutionObject
    {
        [Required]
        public Int32 ri_id { get; set; }

        [Required]
        [MaxLength(40)]
        public String ri_code { get; set; }

        [Required]
        [MaxLength(20)]
        public String shortname { get; set; }

        [Required]
        [MaxLength(256)]
        public String fullname { get; set; }

        [MaxLength(300)]
        public String address { get; set; }

        [Required]
        [MaxLength(10)]
        public String city { get; set; }

        [Required]
        [MaxLength(10)]
        public String lga { get; set; }

        [Required]
        [MaxLength(10)]
        public String state { get; set; }

        [Required]
        [MaxLength(10)]
        public String country_zone { get; set; }

        [MaxLength(3)]
        public String country { get; set; }

        [MaxLength(40)]
        public String postcode { get; set; }

        [MaxLength(20)]
        public String biccode { get; set; }

        [MaxLength(20)]
        public String isocode { get; set; }

        [MaxLength(30)]
        public String telephone_1 { get; set; }

        [MaxLength(30)]
        public String telephone_2 { get; set; }

        [MaxLength(30)]
        public String telephone_3 { get; set; }

        [MaxLength(30)]
        public String mobile { get; set; }

        [MaxLength(30)]
        public String fax { get; set; }

        [MaxLength(320)]
        public String email { get; set; }

        [MaxLength(3)]
        public String lcl_currency { get; set; }

        [MaxLength(3)]
        public String rpt_currency { get; set; }

        [Required]
        public Boolean is_active { get; set; }

        public Int32 admin_user_limit { get; set; }

        public Int32 users_by_admins_count { get; set; }

        [Required]
        public DateTime start_validity_date { get; set; }

        public DateTime end_validity_date { get; set; }

        [MaxLength(40)]
        public String char_cust_element1 { get; set; }

        [MaxLength(40)]
        public String char_cust_element2 { get; set; }

        [MaxLength(40)]
        public String char_cust_element3 { get; set; }

        [MaxLength(40)]
        public String char_cust_element4 { get; set; }

        [MaxLength(40)]
        public String char_cust_element5 { get; set; }

        public String num_cust_element1 { get; set; }

        public String num_cust_element2 { get; set; }

        public String num_cust_element3 { get; set; }

        public String num_cust_element4 { get; set; }

        public String num_cust_element5 { get; set; }

        [Required]
        public DateTime created_date { get; set; }

        [Required]
        [MaxLength(255)]
        public String created_by { get; set; }

        public DateTime last_modified { get; set; }

        [MaxLength(255)]
        public String modified_by { get; set; }
    }
}