namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_core_ri_mapping
    {
        [Key]
        public int ri_mapping_id { get; set; }

        public DateTime start_validity_date { get; set; }

        public DateTime? end_validity_date { get; set; }

        public int ri_id { get; set; }

        public int ri_type_id { get; set; }

        [StringLength(40)]
        public string ri_subtype_code { get; set; }

        public int auth_level_id { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }

        public virtual t_core_reporting_institution t_core_reporting_institution { get; set; }

        public virtual t_core_ri_authorization_level t_core_ri_authorization_level { get; set; }

        public virtual t_core_ri_type t_core_ri_type { get; set; }
    }
}
