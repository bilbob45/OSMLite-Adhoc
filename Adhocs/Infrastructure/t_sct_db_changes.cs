namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_sct_db_changes
    {
        [Key]
        public int change_id { get; set; }

        [Required]
        [StringLength(40)]
        public string type_changes { get; set; }

        [Required]
        [StringLength(40)]
        public string change_code { get; set; }

        [Required]
        [StringLength(50)]
        public string status { get; set; }

        public DateTime change_date { get; set; }

        [Required]
        [StringLength(255)]
        public string change_by { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }

        [Required]
        [StringLength(40)]
        public string change_code_type { get; set; }

        public DateTime? validity_date { get; set; }

        [StringLength(40)]
        public string work_coll_code { get; set; }

        public virtual t_sct_db_changes_code_type t_sct_db_changes_code_type { get; set; }

        public virtual t_sct_db_changes_code_type t_sct_db_changes_code_type1 { get; set; }

        public virtual t_sct_db_changes_status t_sct_db_changes_status { get; set; }

        public virtual t_sct_db_changes_status t_sct_db_changes_status1 { get; set; }

        public virtual t_sct_db_changes_type t_sct_db_changes_type { get; set; }

        public virtual t_sct_db_changes_type t_sct_db_changes_type1 { get; set; }
    }
}
