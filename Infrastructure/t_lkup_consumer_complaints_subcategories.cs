namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_lkup_consumer_complaints_subcategories
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int subcat_id { get; set; }

        public int cat_id { get; set; }

        [Required]
        [StringLength(10)]
        public string sub_category_code { get; set; }

        [Required]
        [StringLength(128)]
        public string sub_category_name { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public virtual t_lkup_consumer_complaints_categories t_lkup_consumer_complaints_categories { get; set; }
    }
}
