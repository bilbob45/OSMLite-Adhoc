namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_fsp_rpt_rs_stylesheet
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int stylesheet_id { get; set; }

        [Key]
        [Column(Order = 1)]
        public string stylesheet_name { get; set; }

        [Key]
        [Column(Order = 2)]
        public byte is_default { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime last_modified { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(255)]
        public string modified_by { get; set; }
    }
}
