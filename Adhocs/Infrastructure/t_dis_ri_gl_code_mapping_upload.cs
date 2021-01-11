namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_dis_ri_gl_code_mapping_upload
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int upload_id { get; set; }

        public int line_nr { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(40)]
        public string ri_code { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(40)]
        public string gl_code { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(40)]
        public string gl_code_2 { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(40)]
        public string gl_code_3 { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(40)]
        public string ccy_code { get; set; }

        [StringLength(1024)]
        public string source_gl_desc { get; set; }

        [Required]
        [StringLength(10)]
        public string source_gl_type { get; set; }

        [Required]
        [StringLength(40)]
        public string dr_bal_item_code { get; set; }

        [Required]
        [StringLength(40)]
        public string cr_bal_item_code { get; set; }

        public DateTime? start_validity_date { get; set; }

        [Required]
        [StringLength(1)]
        public string delete_flag { get; set; }

        [Required]
        [StringLength(1)]
        public string validation_status { get; set; }

        public virtual t_dis_ri_gl_code_mapping_upload_instance t_dis_ri_gl_code_mapping_upload_instance { get; set; }
    }
}
