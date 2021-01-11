namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_msg_history
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_msg_history()
        {
            t_msg_attachment = new HashSet<t_msg_attachment>();
            t_msg_log = new HashSet<t_msg_log>();
        }

        [Key]
        public long msg_hist_id { get; set; }

        public int template_id { get; set; }

        [Required]
        [StringLength(1000)]
        public string msg_subject { get; set; }

        [StringLength(1000)]
        public string msg_body_text { get; set; }

        public string msg_body_html { get; set; }

        [Required]
        [StringLength(255)]
        public string sent_to_user { get; set; }

        [Required]
        [StringLength(128)]
        public string sent_to_address { get; set; }

        public DateTime? sent_to_date { get; set; }

        [StringLength(128)]
        public string email_server_used { get; set; }

        [StringLength(2)]
        public string success_flag { get; set; }

        [StringLength(1024)]
        public string response_text { get; set; }

        [StringLength(128)]
        public string guid_string { get; set; }

        [StringLength(2)]
        public string msg_status { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_msg_attachment> t_msg_attachment { get; set; }

        public virtual t_msg_template t_msg_template { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_msg_log> t_msg_log { get; set; }
    }
}
