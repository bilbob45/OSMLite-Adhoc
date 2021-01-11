namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rtn_work_collection_submission_optn
    {
        [Key]
        public int work_collection_submission_optn_id { get; set; }

        public int work_collection_id { get; set; }

        public long submisssion_id { get; set; }

        [Required]
        [StringLength(40)]
        public string return_code { get; set; }

        [Required]
        [StringLength(1)]
        public string submission_status { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }
    }
}
