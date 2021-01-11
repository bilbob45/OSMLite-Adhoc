namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_currency_type
    {
        [Key]
        [StringLength(15)]
        public string currency_type { get; set; }

        [Required]
        [StringLength(128)]
        public string currency_type_name { get; set; }

        [Required]
        [StringLength(1024)]
        public string currency_type_desc { get; set; }

        public DateTime last_modified { get; set; }

        [Required]
        [StringLength(255)]
        public string modified_by { get; set; }
    }
}
