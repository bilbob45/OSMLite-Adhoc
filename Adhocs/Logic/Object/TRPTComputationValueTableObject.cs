using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Adhocs.Logic.Objects
{
    public class TRPTComputationValueTableObject
    {
        [Required]
        [MaxLength(40)]
        public String computation_rule { get; set; }

        [Required]
        public Int32 version_id { get; set; }

        [Required]
        public Int32 ri_type_id { get; set; }

        [Required]
        public Int32 ri_id { get; set; }

        [Required]
        public DateTime work_collection_date { get; set; }
        //public String work_collection_date { get; set; }

        [Required]
        [MaxLength(2)]
        public String freq_unit { get; set; }

        public String schedule_id { get; set; }

        [Required]
        public Int32 run_id { get; set; }

        [Required]
        [MaxLength(40)]
        public String row_code { get; set; }

        public String column_1 { get; set; }

        public String column_2 { get; set; }

        public String column_3 { get; set; }

        public String column_4 { get; set; }

        public String column_5 { get; set; }

        public String column_6 { get; set; }

        public String column_7 { get; set; }

        public String column_8 { get; set; }

        public String column_9 { get; set; }

        public String column_10 { get; set; }

        public String column_11 { get; set; }

        public String column_12 { get; set; }

        public String column_13 { get; set; }

        public String column_14 { get; set; }

        public String column_15 { get; set; }

        public String column_16 { get; set; }

        public String column_17 { get; set; }

        public String column_18 { get; set; }

        public String column_19 { get; set; }

        public String column_20 { get; set; }

        public String column_21 { get; set; }

        public String column_22 { get; set; }

        public String column_23 { get; set; }

        public String column_24 { get; set; }

        public String column_25 { get; set; }

        public String column_26 { get; set; }

        public String column_27 { get; set; }

        public String column_28 { get; set; }

        public String column_29 { get; set; }

        public String column_30 { get; set; }

        public String column_31 { get; set; }

        public String column_32 { get; set; }

        public String column_33 { get; set; }

        public String column_34 { get; set; }

        public String column_35 { get; set; }

        public String column_36 { get; set; }

        public String column_37 { get; set; }

        public String column_38 { get; set; }

        public String column_39 { get; set; }

        public String column_40 { get; set; }

        public String comment { get; set; }

        [Required]
        public DateTime last_modified { get; set; }

        [Required]
        [MaxLength(255)]
        public String modified_by { get; set; }

    }

}