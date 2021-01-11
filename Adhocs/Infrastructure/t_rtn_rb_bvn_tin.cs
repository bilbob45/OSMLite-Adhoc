namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rtn_rb_bvn_tin
    {
        public long id { get; set; }

        [Required]
        [StringLength(20)]
        public string bvn { get; set; }

        [Required]
        [StringLength(50)]
        public string firstname { get; set; }

        [Required]
        [StringLength(50)]
        public string middlename { get; set; }

        [Required]
        [StringLength(50)]
        public string lastname { get; set; }

        public DateTime? dateofbirth { get; set; }

        [Required]
        [StringLength(50)]
        public string phonenumber1 { get; set; }

        [Required]
        [StringLength(50)]
        public string phonenumber2 { get; set; }

        [Required]
        [StringLength(5)]
        public string gender { get; set; }

        [Required]
        [StringLength(1000)]
        public string residentialaddress { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(50)]
        public string created_by { get; set; }
    }
}
