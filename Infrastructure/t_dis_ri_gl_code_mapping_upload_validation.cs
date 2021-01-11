namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_dis_ri_gl_code_mapping_upload_validation
    {
        [Key]
        public long validation_id { get; set; }

        public int upload_id { get; set; }

        public int line_nr { get; set; }

        public DateTime validation_date { get; set; }

        [Required]
        [StringLength(40)]
        public string validation_msg_code { get; set; }

        [Required]
        [StringLength(1024)]
        public string validation_desc { get; set; }
    }
}
