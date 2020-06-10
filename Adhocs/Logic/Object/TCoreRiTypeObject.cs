using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Adhocs.Logic.Objects
{
    public class TCoreRiTypeObject
    {
        [Required]
        public Int32 ri_type_id { get; set; }

        [Required]
        [MaxLength(40)]
        public String ri_type_code { get; set; }

        [Required]
        [MaxLength(1024)]
        public String description { get; set; }

        [Required]
        public DateTime start_validity_date { get; set; }

        public DateTime end_validity_date { get; set; }

        public Int32 admin_user_limit { get; set; }

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