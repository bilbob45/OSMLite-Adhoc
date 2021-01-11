namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rb_returns_matrix
    {
        [Key]
        public int return_matrix_item_id { get; set; }

        [Required]
        [StringLength(40)]
        public string return_code { get; set; }

        [Required]
        [StringLength(1024)]
        public string dependnecy { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }

        [StringLength(50)]
        public string status_code { get; set; }

        public virtual t_rb_retrun_matrix_status t_rb_retrun_matrix_status { get; set; }

        public virtual t_rb_retrun_matrix_status t_rb_retrun_matrix_status1 { get; set; }
    }
}
