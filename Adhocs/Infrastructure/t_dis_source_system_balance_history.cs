namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_dis_source_system_balance_history
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(40)]
        public string ri_code { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(40)]
        public string gl_code { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(40)]
        public string gl_code_2 { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(40)]
        public string gl_code_3 { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(40)]
        public string ccy_code { get; set; }

        [StringLength(1024)]
        public string source_gl_desc { get; set; }

        [Required]
        [StringLength(10)]
        public string source_gl_type { get; set; }

        [Key]
        [Column(Order = 5)]
        public DateTime bal_date { get; set; }

        public DateTime upload_date { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int upload_count { get; set; }

        [Column(TypeName = "numeric")]
        public decimal dr_mtd_bal { get; set; }

        [Column(TypeName = "numeric")]
        public decimal cr_mtd_bal { get; set; }

        [Column(TypeName = "numeric")]
        public decimal dr_ytd_bal { get; set; }

        [Column(TypeName = "numeric")]
        public decimal cr_ytd_bal { get; set; }

        [Column(TypeName = "numeric")]
        public decimal dr_bal { get; set; }

        [Column(TypeName = "numeric")]
        public decimal cr_bal { get; set; }

        public DateTime last_modified { get; set; }

        [Required]
        [StringLength(255)]
        public string modified_by { get; set; }
    }
}
