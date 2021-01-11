namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_sct_file_packager
    {
        [Key]
        public int sct_file_id { get; set; }

        [Required]
        [StringLength(40)]
        public string parent_name { get; set; }

        [Required]
        [StringLength(40)]
        public string file_name { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }

        public long? Folder { get; set; }

        [StringLength(25)]
        public string extension { get; set; }

        public long? parent_order { get; set; }
    }
}
