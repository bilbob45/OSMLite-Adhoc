using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Adhocs.Logic.Objects
{
    public class VRTNWorkCollectionObject
    {
        [Required]
        public Int32 work_collection_id { get; set; }

        [Required]
        [MaxLength(12)]
        public String entity { get; set; }

        [Required]
        [MaxLength(40)]
        public String work_collection_code { get; set; }

        [Required]
        [MaxLength(1024)]
        public String description { get; set; }

        [Required]
        public Int32 ri_type_id { get; set; }

        [Required]
        [MaxLength(2)]
        public String frequency { get; set; }

        public Int32 delivery_deadline_day { get; set; }

        public Int32 delivery_deadline_hr { get; set; }

        public Int32 delivery_deadline_min { get; set; }

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