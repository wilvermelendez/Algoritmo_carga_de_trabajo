using System.Collections.Generic;
using System.Security.AccessControl;
using System.Security.Principal;

namespace ASPNET_Core_2_1.Models
{
    public class Operator
    {
        public int Id { get; set; }
        public int Month { get; set; }
        public List<Job> Jobs { get; set; }
        public List<Penalty> Penalties { get; set; }
        public decimal Salary { get; set; }
        public decimal PenaltySalary { get; set; }
        public bool Fired { get; set; }
    }
}
