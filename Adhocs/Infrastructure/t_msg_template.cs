namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_msg_template
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_msg_template()
        {
            t_msg_history = new HashSet<t_msg_history>();
        }

        [Key]
        public int template_id { get; set; }

        [Required]
        [StringLength(40)]
        public string module_code { get; set; }

        [Required]
        [StringLength(20)]
        public string msg_type { get; set; }

        [Required]
        [StringLength(40)]
        public string msg_subtype { get; set; }

        [StringLength(1024)]
        public string msg_desc { get; set; }

        [Required]
        [StringLength(1000)]
        public string msg_subject { get; set; }

        [Required]
        [StringLength(1000)]
        public string msg_body_text { get; set; }

        [Required]
        public string msg_body_html { get; set; }

        [Required]
        [StringLength(10)]
        public string delivery_code { get; set; }

        public bool is_enabled { get; set; }

        [StringLength(40)]
        public string char_cust_element1 { get; set; }

        [StringLength(40)]
        public string char_cust_element2 { get; set; }

        [StringLength(40)]
        public string char_cust_element3 { get; set; }

        [StringLength(40)]
        public string char_cust_element4 { get; set; }

        [StringLength(40)]
        public string char_cust_element5 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? num_cust_element1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? num_cust_element2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? num_cust_element3 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? num_cust_element4 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? num_cust_element5 { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }

        public virtual t_msg_delivery_method t_msg_delivery_method { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_msg_history> t_msg_history { get; set; }

        public virtual t_msg_module t_msg_module { get; set; }

        public virtual t_msg_subtype t_msg_subtype { get; set; }

        public virtual t_msg_type t_msg_type { get; set; }
    }
}
