using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Charges
{
    public class InforToCaculateLateCharge
    {
        public float ChargePercent { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? LateChargeID { get; set; }
    }
}
