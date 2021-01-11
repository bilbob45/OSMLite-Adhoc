namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rtn_processing_exceptions
    {
        public int id { get; set; }

        public int? ri_id { get; set; }

        public int? ri_type_id { get; set; }

        [StringLength(128)]
        public string submission_filename { get; set; }

        public DateTime? submission_date { get; set; }

        public string exception_msg { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }
    }
}
