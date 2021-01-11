namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rpt_computation_value_table
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(40)]
        public string computation_rule { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int version_id { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ri_type_id { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ri_id { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(80)]
        public string ri_subtype_code { get; set; }

        [Key]
        [Column(Order = 5)]
        public DateTime work_collection_date { get; set; }

        [Required]
        [StringLength(2)]
        public string freq_unit { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long schedule_id { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int run_id { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(40)]
        public string row_code { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? column_1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? column_2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? column_3 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? column_4 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? column_5 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? column_6 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? column_7 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? column_8 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? column_9 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? column_10 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? column_11 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? column_12 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? column_13 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? column_14 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? column_15 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? column_16 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? column_17 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? column_18 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? column_19 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? column_20 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? column_21 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? column_22 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? column_23 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? column_24 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? column_25 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? column_26 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? column_27 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? column_28 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? column_29 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? column_30 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? column_31 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? column_32 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? column_33 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? column_34 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? column_35 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? column_36 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? column_37 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? column_38 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? column_39 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? column_40 { get; set; }

        [StringLength(2048)]
        public string comment { get; set; }

        public DateTime last_modified { get; set; }

        [Required]
        [StringLength(255)]
        public string modified_by { get; set; }

        public virtual t_core_ri_type t_core_ri_type { get; set; }

        public virtual t_lkup_frequency t_lkup_frequency { get; set; }
    }
}
