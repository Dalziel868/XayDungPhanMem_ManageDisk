namespace Models.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("_Disk")]
    public partial class C_Disk
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C_Disk()
        {
            BillDetails = new HashSet<BillDetail>();
        }

        public int Id { get; set; }

        [Column("_Status")]
        [StringLength(15)]
        public string C_Status { get; set; }

        public int? CategoryId { get; set; }

        public int? TitleID { get; set; }

        public virtual Title Title { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillDetail> BillDetails { get; set; }
    }
}
