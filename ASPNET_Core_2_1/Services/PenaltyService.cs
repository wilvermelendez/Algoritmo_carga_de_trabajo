using ASPNET_Core_2_1.Models;
using System.Collections.Generic;
using System.Linq;

namespace ASPNET_Core_2_1.Services
{
    public class PenaltyService : IPenaltyService
    {
        public List<Penalty> AddPenalty(List<Penalty> penalties)
        {
            penalties.Add(new Penalty
            {
                Id = penalties.Count > 0 ? penalties.Max(x => x.Id) + 1 : 1
            });
            return penalties;
        }
    }
}
