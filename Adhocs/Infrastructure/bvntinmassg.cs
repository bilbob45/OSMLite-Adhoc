namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bvntinmassg")]
    public partial class bvntinmassg
    {
        [Key]
        [StringLength(40)]
        public string return_code { get; set; }

        public int? cnt { get; set; }
    }
}
