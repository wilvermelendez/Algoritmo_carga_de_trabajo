using System.Collections.Generic;

namespace ASPNET_Core_2_1.Models
{
    public class WorkLoad
    {
        public int Month { get; set; }
        public List<Operator> Operators { get; set; }
        public int JobsPerOperatorPerMonth { get; set; }
        public int Demand { get; set; }
        public int JobsPerMontPerOperator { get; set; }

    }
}
