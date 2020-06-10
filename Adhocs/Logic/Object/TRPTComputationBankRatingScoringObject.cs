using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Adhocs.Logic.Object
{
    public class TRPTComputationBankRatingScoringObject
    {
        [Required]
        [MaxLength(200)]
        public String bank_rating_code { get; set; }

        [Required]
        public Int32 ri_type_id { get; set; }

        [Required]
        public Int32 ri_id { get; set; }

        [Required]
        public DateTime rating_date { get; set; }

        public String rating_score { get; set; }

        public DateTime last_modified { get; set; }

        [MaxLength(255)]
        public String modified_by { get; set; }
    }
}