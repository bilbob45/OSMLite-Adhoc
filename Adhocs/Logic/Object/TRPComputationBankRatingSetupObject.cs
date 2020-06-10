using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Adhocs.Logic.Object
{
    public class TRPComputationBankRatingSetupObject
    {
        [Required]
        [MaxLength(200)]
        public String bank_rating_code { get; set; }

        [Required]
        public Int32 ri_type_id { get; set; }

        [Required]
        [MaxLength(128)]
        public String param { get; set; }

        [MaxLength(1024)]
        public String description { get; set; }

        [Required]
        public String component_weight { get; set; }

        [Required]
        public DateTime? start_validity_date { get; set; }

        public DateTime? end_validity_date { get; set; }

        [Required]
        public DateTime created_date { get; set; } = DateTime.Now;

        [Required]
        [MaxLength(255)]
        public String created_by { get; set; }

        public DateTime last_modified { get; set; }

        [MaxLength(255)]
        public String modified_by { get; set; }
    }
}