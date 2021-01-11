namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rtn_rb_tin
    {
        public long id { get; set; }

        [Required]
        [StringLength(20)]
        public string tin { get; set; }

        [Required]
        [StringLength(100)]
        public string tin_tax_payer { get; set; }

        [Required]
        [StringLength(50)]
        public string contact_number { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        [StringLength(20)]
        public string jtb_tin { get; set; }

        [Required]
        [StringLength(50)]
        public string rc_number { get; set; }

        [Required]
        [StringLength(10)]
        public string tax_office_id { get; set; }

        [Required]
        [StringLength(50)]
        public string tax_office_name { get; set; }

        [Required]
        [StringLength(1000)]
        public string tax_payer_address { get; set; }

        [Required]
        [StringLength(10)]
        public string tax_payer_type { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(50)]
        public string created_by { get; set; }
    }
}
