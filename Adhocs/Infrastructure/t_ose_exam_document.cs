namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_ose_exam_document
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_ose_exam_document()
        {
            t_ose_exam_type_document_mapping = new HashSet<t_ose_exam_type_document_mapping>();
        }

        [Key]
        public int doc_id { get; set; }

        [Required]
        [StringLength(40)]
        public string doc_name { get; set; }

        [Required]
        [StringLength(1024)]
        public string doc_desc { get; set; }

        public DateTime start_validity_date { get; set; }

        public DateTime? end_validity_date { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_ose_exam_type_document_mapping> t_ose_exam_type_document_mapping { get; set; }
    }
}
