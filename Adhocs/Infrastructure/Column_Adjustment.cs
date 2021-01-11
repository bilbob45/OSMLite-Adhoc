namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Column_Adjustment
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string RETURN_CODE { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string HEADER_POSITION { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string HEADER_DESC { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string NEW_HEADER_DESC { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(150)]
        public string ACTUAL_LABEL { get; set; }

        [StringLength(50)]
        public string CALCULATION_FIELD { get; set; }
    }
}
