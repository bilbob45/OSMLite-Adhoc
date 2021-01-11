namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tin")]
    public partial class tin
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(40)]
        public string return_code { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(200)]
        public string return_field { get; set; }
    }
}
