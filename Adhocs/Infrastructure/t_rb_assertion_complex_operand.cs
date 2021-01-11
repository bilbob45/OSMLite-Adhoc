namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rb_assertion_complex_operand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long complex_operand_id { get; set; }

        public long operand_id { get; set; }

        [Required]
        [StringLength(100)]
        public string alias { get; set; }

        public int order_number { get; set; }

        [StringLength(40)]
        public string return_code { get; set; }

        [StringLength(100)]
        public string item_code { get; set; }

        [StringLength(200)]
        public string columnname { get; set; }

        [StringLength(100)]
        public string logic_connector_item_code { get; set; }

        [StringLength(100)]
        public string logic_connector_columnname { get; set; }

        [StringLength(100)]
        public string logic_connector_literal { get; set; }

        [Required]
        [StringLength(1)]
        public string is_logic_conn_literal { get; set; }

        [Required]
        [StringLength(1)]
        public string is_boolean_equation { get; set; }

        [Required]
        [StringLength(1)]
        public string is_boolean_ifpart { get; set; }

        [Required]
        [StringLength(1)]
        public string is_boolean_thenpart { get; set; }

        [Required]
        [StringLength(1)]
        public string is_boolean_lhs { get; set; }

        [Required]
        [StringLength(1)]
        public string is_boolean_rhs { get; set; }

        [StringLength(6)]
        public string init_operator_type { get; set; }

        [StringLength(6)]
        public string folowing_operator_type { get; set; }

        [StringLength(6)]
        public string logic_connector_type { get; set; }

        [StringLength(6)]
        public string logic_operator_type { get; set; }

        [StringLength(6)]
        public string complex_operator_type { get; set; }

        [StringLength(1024)]
        public string place_holder { get; set; }

        [Required]
        [StringLength(1)]
        public string is_boolean_complex { get; set; }

        public int version_id { get; set; }

        public DateTime valid_from { get; set; }

        public bool is_active { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }

        public virtual t_rb_assertion_operand t_rb_assertion_operand { get; set; }
    }
}
