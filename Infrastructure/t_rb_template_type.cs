namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rb_template_type
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int template_id { get; set; }

        [Required]
        [StringLength(20)]
        public string description { get; set; }

        [Required]
        [StringLength(20)]
        public string type { get; set; }

        public DateTime? created_date { get; set; }

        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime last_modified { get; set; }

        [Required]
        [StringLength(255)]
        public string modified_by { get; set; }
    }
}
