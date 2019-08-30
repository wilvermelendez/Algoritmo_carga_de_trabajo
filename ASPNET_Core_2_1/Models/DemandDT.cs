using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET_Core_2_1.Models
{
    public class DemandDT
    {
        public int Id { get; set; }
        public int Month { get; set; }
        public int Jobs { get; set; }
        public int Salario { get; set; }
        public int PenaltySalary { get; set; }
    }
}
