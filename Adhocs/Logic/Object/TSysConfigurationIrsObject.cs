using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Adhocs.Logic.Object
{
    public class TSysConfigurationIrsObject
    {
        [Required]
        public Int32 config_id { get; set; }

        [Required]
        [MaxLength(255)]
        public String default_value { get; set; }

        [Required]
        [MaxLength(255)]
        public String config_value { get; set; }

        [Required]
        public Int32 enabled { get; set; }

        [Required]
        [MaxLength(1000)]
        public String config_value_desc { get; set; }

        [Required]
        public DateTime last_modified { get; set; }

        [Required]
        [MaxLength(255)]
        public String modified_by { get; set; }
    }
}