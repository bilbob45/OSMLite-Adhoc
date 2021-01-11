using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Adhocs.Logic.Object
{
    public class TRTNBuilderUploadObject
    {
        [Required]
        public Int32 id { get; set; }

        [Required]
        [MaxLength(128)]
        public String file_name { get; set; }

        [Required]
        public DateTime upload_date { get; set; }

        [MaxLength(128)]
        public String build_number { get; set; }

        [Required]
        public Boolean is_current { get; set; }

        [Required]
        [MaxLength(128)]
        public String uploaded_by { get; set; }
    }
}