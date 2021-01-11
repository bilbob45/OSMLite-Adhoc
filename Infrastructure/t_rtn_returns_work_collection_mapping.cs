namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rtn_returns_work_collection_mapping
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int work_collection_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(40)]
        public string return_code { get; set; }

        public DateTime start_validity_date { get; set; }

        public DateTime? end_validity_date { get; set; }

        public int version_valid_from { get; set; }

        public int? version_valid_to { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }

        public virtual t_rtn_returns t_rtn_returns { get; set; }

        public virtual t_rtn_work_collection_defn t_rtn_work_collection_defn { get; set; }
    }
}
