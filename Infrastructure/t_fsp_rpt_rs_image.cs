namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_fsp_rpt_rs_image
    {
        [Key]
        [Column(Order = 0)]
        public string filename { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int stylesheet_id { get; set; }

        [Key]
        [Column(Order = 2)]
        public byte is_default { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(6)]
        public string image_type { get; set; }

        [Key]
        [Column(Order = 4)]
        public byte[] reference { get; set; }

        [Key]
        [Column(Order = 5)]
        public DateTime last_modified { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(255)]
        public string modified_by { get; set; }
    }
}
