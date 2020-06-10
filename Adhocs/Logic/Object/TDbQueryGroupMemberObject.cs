using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Adhocs.Logic.Object
{
    public class TDbQueryGroupMemberObject
    {
        [Required]
        public Int32 group_id { get; set; }

        [Required]
        public Int32 user_id { get; set; }

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