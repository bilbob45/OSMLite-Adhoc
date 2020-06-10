using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Adhocs.Logic.Object
{
    public class TCoreDeptUnit
    {
        [Required]
        public Int32 unit_id { get; set; }

        [Required]
        [MaxLength(128)]
        public String unit_name { get; set; }

        [Required]
        [MaxLength(128)]
        public String unit_desc { get; set; }

        [Required]
        public String is_active { get; set; }

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