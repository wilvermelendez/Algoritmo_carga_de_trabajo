using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET_Core_2_1.DTO
{
    public class OperatorPerMonth
    {
        public int Month { get; set; }
        public int OperatorQuantity{ get; set; }
        public int DemandPerMonth { get; set; }
        public int JobsPerOperatorPerMonth { get; set; }
    }
}
