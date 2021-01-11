namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_core_users_ext
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int user_id { get; set; }

        [Required]
        [StringLength(10)]
        public string staff_id { get; set; }

        public bool signature { get; set; }

        public int grade_id { get; set; }

        public int designation_id { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime start_validity_date { get; set; }

        public DateTime? end_validity_date { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }

        public virtual t_core_user_designation t_core_user_designation { get; set; }

        public virtual t_core_user_grade t_core_user_grade { get; set; }

        public virtual t_core_users t_core_users { get; set; }
    }
}
