using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Adhocs.Logic.Objects
{
    public class TRPTComputationRuleAdjustmentObject
    {
        [Required]
        public String schedule_id { get; set; }

        [Required]
        public Int32 run_id { get; set; }

        [Required]
        public Int32 process_flag { get; set; }

        [Required]
        [MaxLength(1024)]
        public String analyst_comment { get; set; }

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