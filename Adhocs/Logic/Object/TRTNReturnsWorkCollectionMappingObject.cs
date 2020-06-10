using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Adhocs.Logic.Objects
{
    public class TRTNReturnsWorkCollectionMappingObject
    {
        [Required]
        public Int32 work_collection_id { get; set; }

        [Required]
        [MaxLength(40)]
        public String return_code { get; set; }

        [Required]
        public DateTime start_validity_date { get; set; }

        public DateTime end_validity_date { get; set; }

        [Required]
        public Int32 version_valid_from { get; set; }

        public Int32 version_valid_to { get; set; }

        [Required]
        public DateTime created_date { get; set; }

        [Required]
        [MaxLength(255)]
        public String created_by { get; set; }

        public DateTime last_modified { get; set; }

        [MaxLength(255)]
        public String modified_by { get; set; }

    }
}