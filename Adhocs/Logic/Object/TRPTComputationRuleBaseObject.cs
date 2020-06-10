using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Adhocs.Logic.Objects
{
    public class TRPTComputationRuleBaseObject
    {
        [Required]
        public Int32 rule_ID { get; set; }

        [Required]
        [MaxLength(50)]
        public String rule_Name { get; set; }

        [Required]
        [MaxLength(500)]
        public String rule_Desc { get; set; }

        public Int32 version_id { get; set; }

        [MaxLength(20)]
        public String rule_status { get; set; }

        [Required]
        [MaxLength(4000)]
        public String formula { get; set; }

        [Required]
        [MaxLength(40)]
        public String type { get; set; }

        public Int32 ruleColumnNos { get; set; }

        public Int32 ruleRowNos { get; set; }

        [Required]
        public DateTime created_date { get; set; }

        [Required]
        [MaxLength(255)]
        public String created_by { get; set; }

        public DateTime last_modified { get; set; }

        [MaxLength(255)]
        public String modified_by { get; set; }

        [MaxLength(25)]
        public String rule_freq { get; set; }

        [MaxLength(25)]
        public String rule_ri { get; set; }

        [MaxLength(20)]
        public String trend { get; set; }

        [MaxLength(2)]
        public String is_global { get; set; }
    }
}