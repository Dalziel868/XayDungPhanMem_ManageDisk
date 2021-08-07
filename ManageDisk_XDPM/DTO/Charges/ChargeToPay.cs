using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Charges
{
    public class ChargeToPay
    {
        public decimal LateCharge { get; set; }
        public int NumberOfDaysLate { get; set; }
        public Guid RowID { get; set; }
    }
}
