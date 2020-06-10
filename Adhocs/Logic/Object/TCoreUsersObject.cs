using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Adhocs.Logic.Object
{
    public class TCoreUsersObject
    {
        [Required]
        public Int32 user_id { get; set; }

        [Required]
        [MaxLength(255)]
        public String user_name { get; set; }

        [Required]
        [MaxLength(128)]
        public String last_name { get; set; }

        [Required]
        [MaxLength(128)]
        public String first_name { get; set; }

        [MaxLength(128)]
        public String middle_name { get; set; }

        [Required]
        [MaxLength(128)]
        public String app_user_id { get; set; }

        [Required]
        public Boolean is_regulator { get; set; }

        [Required]
        [MaxLength(40)]
        public String user_inst { get; set; }

        [MaxLength(320)]
        public String email { get; set; }

        [Required]
        public Boolean is_active { get; set; }

        [Required]
        public DateTime last_visit_on { get; set; }

        [Required]
        public Boolean system_person { get; set; }

        [Required]
        [MaxLength(8)]
        public String auth_code { get; set; }

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

        [Required]
        public Boolean sct_download { get; set; }

    }
}