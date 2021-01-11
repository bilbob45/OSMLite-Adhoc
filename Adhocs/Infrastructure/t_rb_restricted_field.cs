namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rb_restricted_field
    {
        [Key]
        public int restricted_field_id { get; set; }

        [Required]
        [StringLength(40)]
        public string return_code { get; set; }

        [Required]
        [StringLength(200)]
        public string return_field { get; set; }

        [Required]
        [StringLength(40)]
        public string restriction_code { get; set; }

        [Required]
        [StringLength(5)]
        public string version_code { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }

        public virtual t_rb_restriction_codes t_rb_restriction_codes { get; set; }

        public virtual t_rb_restriction_codes t_rb_restriction_codes1 { get; set; }

        public virtual t_rb_restriction_codes t_rb_restriction_codes2 { get; set; }

        public virtual t_rb_restriction_codes t_rb_restriction_codes3 { get; set; }

        public virtual t_rb_restriction_codes t_rb_restriction_codes4 { get; set; }

        public virtual t_rb_restriction_codes t_rb_restriction_codes5 { get; set; }
    }
}
