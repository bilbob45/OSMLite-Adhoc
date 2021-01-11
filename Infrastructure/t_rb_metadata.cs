namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rb_metadata
    {
        [Key]
        public long mdata_id { get; set; }

        [StringLength(20)]
        public string ri_type_code { get; set; }

        [Required]
        [StringLength(20)]
        public string return_code { get; set; }

        [StringLength(2000)]
        public string header_desc { get; set; }

        [Required]
        [StringLength(100)]
        public string xml_name { get; set; }

        [Required]
        [StringLength(10)]
        public string header_position { get; set; }

        [Required]
        [StringLength(100)]
        public string table_name { get; set; }

        public int datatype_id { get; set; }

        public int datasize_id { get; set; }

        [StringLength(2000)]
        public string actual_label { get; set; }

        [StringLength(3)]
        public string vertical_merged { get; set; }

        [StringLength(3)]
        public string horizontal_merged { get; set; }

        [StringLength(200)]
        public string merged_range { get; set; }

        public DateTime? created_date { get; set; }

        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime last_modified { get; set; }

        [Required]
        [StringLength(255)]
        public string modified_by { get; set; }

        [StringLength(2)]
        public string iscustom { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? custom_size { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? precisionz { get; set; }

        public byte is_total { get; set; }

        public virtual t_rb_datasize t_rb_datasize { get; set; }

        public virtual t_rb_datasize t_rb_datasize1 { get; set; }

        public virtual t_rb_datatype t_rb_datatype { get; set; }

        public virtual t_rb_datatype t_rb_datatype1 { get; set; }
    }
}
