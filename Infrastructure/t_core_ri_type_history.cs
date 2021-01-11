namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_core_ri_type_history
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ri_type_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(40)]
        public string ri_type_code { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(1024)]
        public string description { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime start_validity_date { get; set; }

        public DateTime? end_validity_date { get; set; }

        public int? admin_user_limit { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime created_date { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }
    }
}
