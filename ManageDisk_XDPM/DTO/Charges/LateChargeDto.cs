using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Charges
{
    public class LateChargeDto
    {

        private float chargePercent;
        private decimal? unitPrice;
        public float ChargePercent { set { this.chargePercent = value; } }
        public decimal? UnitPrice { set { this.unitPrice = value; } }
        public decimal LateCharge
        {
            get
            {
                decimal chargePercent = Convert.ToDecimal(this.chargePercent);
                decimal price = this.unitPrice ?? 0;
                return (chargePercent * price);
            }
        }

    }
}
