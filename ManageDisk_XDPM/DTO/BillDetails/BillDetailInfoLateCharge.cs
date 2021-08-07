using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.BillDetails
{
    public class BillDetailInfoLateCharge
    {
        private decimal unitPrice;
        private float chargePercent;
        public string DiskName { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int NumberOfDaysLate
        {
            get
            {
                    TimeSpan span = (TimeSpan)(ReturnDate - DueDate);
                    return span.Days;
            }
        }
        public decimal UnitPrice { set { this.unitPrice = value; } }
        public float ChargePercent { set { this.chargePercent = value; } }
        
        public decimal LateCharge
        {
            get
            {
                decimal convertPercent = Convert.ToDecimal(this.chargePercent);
                return this.unitPrice * convertPercent;
            }
            
        }
    }
}
