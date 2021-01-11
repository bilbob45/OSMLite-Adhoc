namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rpt_computation_bank_rating_setup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_rpt_computation_bank_rating_setup()
        {
            t_rpt_computation_bank_rating_scoring = new HashSet<t_rpt_computation_bank_rating_scoring>();
        }

        [Key]
        [StringLength(200)]
        public string bank_rating_code { get; set; }

        public int ri_type_id { get; set; }

        [Required]
        [StringLength(128)]
        public string param { get; set; }

        [StringLength(1024)]
        public string description { get; set; }

        [Column(TypeName = "numeric")]
        public decimal component_weight { get; set; }

        public DateTime start_validity_date { get; set; }

        public DateTime? end_validity_date { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }

        public virtual t_core_ri_type t_core_ri_type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rpt_computation_bank_rating_scoring> t_rpt_computation_bank_rating_scoring { get; set; }
    }
}
