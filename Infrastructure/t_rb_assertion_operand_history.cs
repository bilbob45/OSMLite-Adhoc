namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rb_assertion_operand_history
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long operand_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string alias { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int order_number { get; set; }

        [StringLength(100)]
        public string item_code { get; set; }

        [StringLength(200)]
        public string columnname { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(1)]
        public string is_boolean_equation { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(1)]
        public string is_boolean_lhs { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(1)]
        public string is_boolean_rhs { get; set; }

        [StringLength(6)]
        public string init_operator_type { get; set; }

        [StringLength(6)]
        public string folowing_operator_type { get; set; }

        [StringLength(6)]
        public string complex_operator_type { get; set; }

        [StringLength(1024)]
        public string place_holder { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(1)]
        public string is_boolean_complex { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int version_id { get; set; }

        [Key]
        [Column(Order = 8)]
        public DateTime valid_from { get; set; }

        [Key]
        [Column(Order = 9)]
        public bool is_active { get; set; }

        [Key]
        [Column(Order = 10)]
        public DateTime created_date { get; set; }

        [Key]
        [Column(Order = 11)]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }
    }
}
