using ASPNET_Core_2_1.Models;
using System.Collections.Generic;
using System.Linq;

namespace ASPNET_Core_2_1.Services
{
    public class JobService : IJobService
    {
        public List<Job> AddJob(List<Job> jobs)
        {
            var job = new Job
            {
                Id = jobs.Count > 0 ? jobs.Max(x => x.Id) + 1 : 1
            };
            jobs.Add(job);
            return jobs;
        }
    }
}
