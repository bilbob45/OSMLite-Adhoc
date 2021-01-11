namespace Adhocs.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_sct_webservice_url
    {
        [Key]
        [StringLength(50)]
        public string name { get; set; }

        [StringLength(2000)]
        public string web_service_url { get; set; }
    }
}
