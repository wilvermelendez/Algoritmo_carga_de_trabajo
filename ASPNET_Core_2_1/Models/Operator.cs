using System.Collections.Generic;

namespace ASPNET_Core_2_1.Models
{
    public class Operator
    {
        public Operator()
        {
            Fired = false;
            Jobs = new List<Job>();
            Penalties = new List<Penalty>();
            PenaltySalary = 0;
        }
      

        public int Id { get; set; }
        public int Month { get; set; }
        public List<Jobs> Trabajos { get; set; }
        public List<Job> Jobs { get; set; }
        public List<Penalty> Penalties { get; set; }
        public decimal Salary { get; set; }
        public decimal PenaltySalary { get; set; }
        public bool Fired { get; set; }


    }
}
