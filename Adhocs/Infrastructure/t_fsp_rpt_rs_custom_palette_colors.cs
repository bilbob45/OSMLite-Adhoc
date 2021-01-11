namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_fsp_rpt_rs_custom_palette_colors
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int stylesheet_id { get; set; }

        [Key]
        [Column(Order = 1)]
        public string style_name { get; set; }

        [StringLength(40)]
        public string color1 { get; set; }

        [StringLength(40)]
        public string color2 { get; set; }

        [StringLength(40)]
        public string color3 { get; set; }

        [StringLength(40)]
        public string color4 { get; set; }

        [StringLength(40)]
        public string color5 { get; set; }

        [StringLength(40)]
        public string color6 { get; set; }

        [StringLength(40)]
        public string color7 { get; set; }

        [StringLength(40)]
        public string color8 { get; set; }

        [StringLength(40)]
        public string color9 { get; set; }

        [StringLength(40)]
        public string color10 { get; set; }

        [StringLength(40)]
        public string color11 { get; set; }

        [StringLength(40)]
        public string color12 { get; set; }

        [StringLength(40)]
        public string color13 { get; set; }

        [StringLength(40)]
        public string color14 { get; set; }

        [StringLength(40)]
        public string color15 { get; set; }

        [StringLength(40)]
        public string color16 { get; set; }

        [StringLength(40)]
        public string color17 { get; set; }

        [StringLength(40)]
        public string color18 { get; set; }

        [StringLength(40)]
        public string color19 { get; set; }

        [StringLength(40)]
        public string color20 { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime last_modified { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(255)]
        public string modified_by { get; set; }
    }
}
