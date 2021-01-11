namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_currency_code
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_currency_code()
        {
            t_crsb_msg_incoming = new HashSet<t_crsb_msg_incoming>();
            t_crsb_msg_outgoing = new HashSet<t_crsb_msg_outgoing>();
        }

        [Key]
        [StringLength(3)]
        public string currency { get; set; }

        public DateTime start_validity_date { get; set; }

        public DateTime end_validity_date { get; set; }

        [Required]
        [StringLength(1024)]
        public string description { get; set; }

        public int number_of_dec_places { get; set; }

        public bool emu_member_ind { get; set; }

        public int year_basis { get; set; }

        public DateTime active_until_date { get; set; }

        [Required]
        [StringLength(30)]
        public string char_cust_element1 { get; set; }

        [Required]
        [StringLength(30)]
        public string char_cust_element2 { get; set; }

        [Required]
        [StringLength(30)]
        public string char_cust_element3 { get; set; }

        [Required]
        [StringLength(30)]
        public string char_cust_element4 { get; set; }

        [Required]
        [StringLength(30)]
        public string char_cust_element5 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal num_cust_element1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal num_cust_element2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal num_cust_element3 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal num_cust_element4 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal num_cust_element5 { get; set; }

        public DateTime last_modified { get; set; }

        [Required]
        [StringLength(255)]
        public string modified_by { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_crsb_msg_incoming> t_crsb_msg_incoming { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_crsb_msg_outgoing> t_crsb_msg_outgoing { get; set; }
    }
}
