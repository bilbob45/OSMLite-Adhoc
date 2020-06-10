using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Adhocs.Logic.Object
{
    public class TRPTLiqStressTestScoringObject
    {
        [Required]
        [MaxLength(80)]
        public String item_code { get; set; }

        [MaxLength(1024)]
        public String item_description { get; set; }

        [Required]
        public Int32 ri_id { get; set; }

        [Required]
        public DateTime valuation_date { get; set; }

        public String amount { get; set; }

        public DateTime last_modified { get; set; }

        [MaxLength(255)]
        public String modified_by { get; set; }

    }
}