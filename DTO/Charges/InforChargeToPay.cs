using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Charges
{
    public class InforChargeToPay
    {
        public float ChargePercent { get; set; }
        public DateTime DueDate { get; set; }
        public decimal? UnitPrice { get; set; }

        public Guid RowID { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
