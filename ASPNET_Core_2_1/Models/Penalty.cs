using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace ASPNET_Core_2_1.Models
{
    public class Penalty
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public bool Used { get; set; }
    }
}
