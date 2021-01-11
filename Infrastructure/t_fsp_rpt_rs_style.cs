namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_fsp_rpt_rs_style
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int stylesheet_id { get; set; }

        [Key]
        [Column(Order = 1)]
        public string style_name { get; set; }

        [StringLength(128)]
        public string parent_style_name { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(1)]
        public string object_type { get; set; }

        [StringLength(40)]
        public string backgroundcolor { get; set; }

        [StringLength(40)]
        public string backgroundimage_value { get; set; }

        [StringLength(40)]
        public string backgroundimage_backgroundrepeat { get; set; }

        [StringLength(40)]
        public string bookmark { get; set; }

        [StringLength(40)]
        public string bordercolor_default { get; set; }

        [StringLength(40)]
        public string bordercolor_left { get; set; }

        [StringLength(40)]
        public string bordercolor_right { get; set; }

        [StringLength(40)]
        public string bordercolor_top { get; set; }

        [StringLength(40)]
        public string bordercolor_bottom { get; set; }

        [StringLength(40)]
        public string borderstyle_default { get; set; }

        [StringLength(40)]
        public string borderstyle_left { get; set; }

        [StringLength(40)]
        public string borderstyle_right { get; set; }

        [StringLength(40)]
        public string borderstyle_top { get; set; }

        [StringLength(40)]
        public string borderstyle_bottom { get; set; }

        [StringLength(40)]
        public string borderwidth_default { get; set; }

        [StringLength(40)]
        public string borderwidth_left { get; set; }

        [StringLength(40)]
        public string borderwidth_right { get; set; }

        [StringLength(40)]
        public string borderwidth_top { get; set; }

        [StringLength(40)]
        public string borderwidth_bottom { get; set; }

        [StringLength(40)]
        public string calendar { get; set; }

        [StringLength(40)]
        public string color { get; set; }

        [StringLength(40)]
        public string direction { get; set; }

        [StringLength(40)]
        public string font_style { get; set; }

        [StringLength(40)]
        public string font_family { get; set; }

        [StringLength(40)]
        public string font_size { get; set; }

        [StringLength(40)]
        public string font_weight { get; set; }

        [StringLength(40)]
        public string format { get; set; }

        [StringLength(40)]
        public string label { get; set; }

        [StringLength(40)]
        public string labellocid { get; set; }

        [StringLength(40)]
        public string norows { get; set; }

        [StringLength(40)]
        public string numeralvariant { get; set; }

        [StringLength(40)]
        public string padding_left { get; set; }

        [StringLength(40)]
        public string padding_right { get; set; }

        [StringLength(40)]
        public string padding_top { get; set; }

        [StringLength(40)]
        public string padding_bottom { get; set; }

        [StringLength(40)]
        public string textalign { get; set; }

        [StringLength(40)]
        public string textdecoration { get; set; }

        [StringLength(40)]
        public string tooltip { get; set; }

        [StringLength(40)]
        public string tooltiplocid { get; set; }

        [StringLength(40)]
        public string unicodebidi { get; set; }

        [StringLength(40)]
        public string value { get; set; }

        [StringLength(40)]
        public string valuelocid { get; set; }

        [StringLength(40)]
        public string verticalalign { get; set; }

        [StringLength(40)]
        public string writingmode { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime last_modified { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(255)]
        public string modified_by { get; set; }
    }
}
