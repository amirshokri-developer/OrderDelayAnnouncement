using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDelayAnnouncement.Domain.Models
{
    public class VendorAverage
    {
        public int VendorId { get; set; }

        public double? DelayAverage { get; set; }
    }
}
