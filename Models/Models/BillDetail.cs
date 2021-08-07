namespace Models.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BillDetail")]
    public partial class BillDetail
    {
        public int BillID { get; set; }

        public int DiskID { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public int? LateChargeID { get; set; }

        [Key]
        public Guid RowID { get; set; }

        public virtual C_Disk C_Disk { get; set; }

        public virtual Bill Bill { get; set; }

        public virtual LateCharge LateCharge { get; set; }
    }
}
