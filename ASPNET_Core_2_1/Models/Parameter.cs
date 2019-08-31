using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET_Core_2_1.Models
{
    public class Parameter
    {
        public int Id { get; set; }
        public int HoursPerJobs { get; set; }
        public int PricePerJob { get; set; }
        public int Percentage { get; set; }
    }
}
