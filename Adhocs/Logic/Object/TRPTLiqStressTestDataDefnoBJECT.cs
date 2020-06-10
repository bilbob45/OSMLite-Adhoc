using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Adhocs.Logic.Object
{
    public class TRPTLiqStressTestDataDefnObject
    {
        [Required]
        [MaxLength(80)]
        public String report_code { get; set; }

        [Required]
        [MaxLength(80)]
        public String report_section { get; set; }

        [Required]
        [MaxLength(80)]
        public String item_code { get; set; }

        [MaxLength(1024)]
        public String item_description { get; set; }

        [Required]
        public DateTime start_validity_date { get; set; }

        public DateTime end_validity_date { get; set; }

        [MaxLength(80)]
        public String font_color { get; set; }

        [MaxLength(80)]
        public String font_weight { get; set; }

        [MaxLength(80)]
        public String background_color { get; set; }

        [Required]
        public Boolean user_input_reqd { get; set; }

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