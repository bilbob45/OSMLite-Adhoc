namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rtn_work_collection_submission
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_rtn_work_collection_submission()
        {
            t_rtn_work_collection_submission_partial_acc = new HashSet<t_rtn_work_collection_submission_partial_acc>();
        }

        [Key]
        public long submission_id { get; set; }

        public long schedule_id { get; set; }

        [Required]
        [StringLength(128)]
        public string submission_filename { get; set; }

        public DateTime delivery_datetime { get; set; }

        public DateTime? validation_datetime { get; set; }

        [Required]
        [StringLength(1)]
        public string validation_status { get; set; }

        public string validation_msg { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }

        public virtual t_lkup_wc_submission_status t_lkup_wc_submission_status { get; set; }

        public virtual t_rtn_work_collection_schedule t_rtn_work_collection_schedule { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_rtn_work_collection_submission_partial_acc> t_rtn_work_collection_submission_partial_acc { get; set; }
    }
}
