namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class metatada_mig
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string return_code { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string table_name { get; set; }

        [StringLength(2000)]
        public string header_desc { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string header_position { get; set; }

        [StringLength(2000)]
        public string new_header { get; set; }
    }
}
