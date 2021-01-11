namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_db_query_group
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_db_query_group()
        {
            t_db_query_group_member = new HashSet<t_db_query_group_member>();
            t_db_query_group_schema_mapping = new HashSet<t_db_query_group_schema_mapping>();
            t_db_query_user_table_column = new HashSet<t_db_query_user_table_column>();
        }

        [Key]
        public int group_id { get; set; }

        [Required]
        [StringLength(128)]
        public string group_name { get; set; }

        [Required]
        [StringLength(1024)]
        public string group_desc { get; set; }

        public bool is_active { get; set; }

        public DateTime created_date { get; set; }

        [Required]
        [StringLength(255)]
        public string created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [StringLength(255)]
        public string modified_by { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_db_query_group_member> t_db_query_group_member { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_db_query_group_schema_mapping> t_db_query_group_schema_mapping { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_db_query_user_table_column> t_db_query_user_table_column { get; set; }
    }
}
