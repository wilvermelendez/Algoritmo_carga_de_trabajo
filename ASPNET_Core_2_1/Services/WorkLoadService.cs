using ASPNET_Core_2_1.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace ASPNET_Core_2_1.Services
{
    public class WorkLoadService : IWorkLoadService
    {
        public IJsonService JsonService { get; set; }
        public IDemandService DemandService { get; set; }
        public IOperatorService OperatorService { get; set; }
        public IJobService JobService { get; set; }
        public IPenaltyService PenaltyService { get; set; }



        public WorkLoadService(IJsonService jsonService, IDemandService demandService, IOperatorService operatorService, IJobService jobService, IPenaltyService penaltyService)
        {
            JsonService = jsonService;
            DemandService = demandService;
            OperatorService = operatorService;
            JobService = jobService;
        }

        public List<WorkLoad> GenerateWorkLoads()
        {
            var workLoad = new List<WorkLoad>();

            //TODO move to right place and get from the configuration of the main page
            const double hoursPerJob = 2.0;
            const double hoursPerDay = 8.0;
            var daysWorkPerMonth = 20;
            var worksPerDay = Convert.ToInt32(Math.Floor(hoursPerDay / hoursPerJob));
            var maxNumberJobsPerOperatorInMonth = worksPerDay * daysWorkPerMonth;
            var demandData = DemandService.GetDemands();

            foreach (var demand in demandData)
            {
                if (demand.Quantity <= 0) continue;
                //for each month calculate the required number of operators
                var remainder = (demand.Quantity % maxNumberJobsPerOperatorInMonth) > 0 ? 1 : 0;
                var nominalOperatorRequired = (demand.Quantity / maxNumberJobsPerOperatorInMonth) + remainder;
                var operators = OperatorService.CreateOperatorsList(nominalOperatorRequired);
                var counterOperator = 0;
                workLoad.Add
                (
                    new WorkLoad
                    {
                        Month = demand.Month,
                        Operators = operators
                    }
                );

                for (var i = 1; i <= demand.Quantity; i++)
                {

                    if (counterOperator >= nominalOperatorRequired)
                        counterOperator = 0;
                    //try assign each job to every operator one by ony

                    operators[counterOperator].Jobs = JobService.AddJob(operators[counterOperator].Jobs);
                    //after assign the job we must assign an score between 1 and 5, if the score is between 1 and 3 you mush punish the operator, you won't assign next job and will add one penalty
                    //TODO add penalty code


                    counterOperator += 1;
                }
            }

            return workLoad;
        }

        public List<WorkLoad> GetWorkLoads() => JsonService.LoadJson<WorkLoad>($"{Path.GetDirectoryName(System.IO.Path.GetFullPath("WorkLoad.json"))}/Data/WorkLoad.json");

        public bool SaveWorkLoad(List<WorkLoad> workLoads)
        {
            JsonService.SaveJson<WorkLoad>(workLoads, $"{Path.GetDirectoryName(System.IO.Path.GetFullPath("DatosGrafica.json"))}/Data/WorkLoad.json");
            return true;
        }


    }
}
