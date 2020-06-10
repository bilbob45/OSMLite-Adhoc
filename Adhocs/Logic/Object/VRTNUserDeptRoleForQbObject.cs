using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Adhocs.Logic.Object
{
    public class VRTNUserDeptRoleForQbObject
    {
        [Required]
        public Int32 user_id { get; set; }

        [Required]
        [MaxLength(255)]
        public String user_name { get; set; }

        [Required]
        [MaxLength(128)]
        public String role_desc { get; set; }

        [Required]
        [MaxLength(128)]
        public String role_name { get; set; }
    }
}