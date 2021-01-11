namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_crsb_msg_outgoing
    {
        [Key]
        public int msg_id { get; set; }

        [Required]
        [StringLength(40)]
        public string ri_code { get; set; }

        [Required]
        [StringLength(40)]
        public string src_bic_code { get; set; }

        [Required]
        [StringLength(40)]
        public string dest_bic_code { get; set; }

        [StringLength(1024)]
        public string sender { get; set; }

        [StringLength(1024)]
        public string dest_bank { get; set; }

        [Required]
        [StringLength(40)]
        public string beneficiary_account_no { get; set; }

        [StringLength(128)]
        public string beneficiary_name { get; set; }

        [Required]
        [StringLength(10)]
        public string country_code { get; set; }

        [Required]
        [StringLength(3)]
        public string currency { get; set; }

        public DateTime value_date { get; set; }

        [Column(TypeName = "numeric")]
        public decimal amount { get; set; }

        [Column(TypeName = "numeric")]
        public decimal dollar_equiv { get; set; }

        [StringLength(1024)]
        public string purpose { get; set; }

        [StringLength(40)]
        public string purpose_code { get; set; }

        [StringLength(1024)]
        public string purpose_description { get; set; }

        [StringLength(40)]
        public string duration { get; set; }

        [Required]
        [StringLength(40)]
        public string source { get; set; }

        [Required]
        [StringLength(40)]
        public string msg_type { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? sender_charges { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? beneficiary_charges { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }

        [StringLength(128)]
        public string msg_filename { get; set; }

        public virtual t_crsb_msg_source t_crsb_msg_source { get; set; }

        public virtual t_crsb_msg_type t_crsb_msg_type { get; set; }

        public virtual t_currency_code t_currency_code { get; set; }
    }
}
