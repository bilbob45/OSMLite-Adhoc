using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Adhocs.Logic.Objects
{
    public class TRTNWorkCollectionScheduleObject
    {
        [Required]
        public String schedule_id { get; set; }

        [Required]
        public Int32 ri_id { get; set; }

        [Required]
        public Int32 work_collection_id { get; set; }

        [Required]
        public DateTime work_collection_date { get; set; }

        public DateTime schedule_deadline { get; set; }

        public Int32 workflow_id { get; set; }

        [Required]
        public Int32 status_id { get; set; }

        [Required]
        public Boolean resubmit_req { get; set; }

        [Required]
        public Int32 resubmit_count { get; set; }

        [Required]
        public Int32 validation_count { get; set; }

        [Required]
        public Boolean is_valid { get; set; }

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