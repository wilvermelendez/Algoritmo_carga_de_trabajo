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
        public IParameterService ParameterService { get; set; }



        public WorkLoadService(IJsonService jsonService, IDemandService demandService, IOperatorService operatorService, IJobService jobService, IPenaltyService penaltyService, IParameterService parameterService)
        {
            JsonService = jsonService;
            DemandService = demandService;
            OperatorService = operatorService;
            JobService = jobService;
            ParameterService = parameterService;
        }

        public List<WorkLoad> GenerateWorkLoads()
        {
            var workLoad = new List<WorkLoad>();

            //TODO move to right place and get from the configuration of the main page
            //Parametros para el calculo de trabajos de operador por Mes
            var parameter = ParameterService.GetParameters();
            var hoursPerJob = double.Parse(parameter.tiempoxTrabajo.ToString());
            var hoursPerDay = double.Parse(parameter.tiempoxTrabajo.ToString())*8;
            var daysWorkPerMonth = 20;
            //calculo de trabajos de operadores por mes
            var worksPerDay = Convert.ToInt32(Math.Floor(hoursPerDay / hoursPerJob));
            var maxNumberJobsPerOperatorInMonth = worksPerDay * daysWorkPerMonth;
            //obtenemos la demanda acorde al origen de los datos
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
                        Operators = operators,
                        Demand = demand.Quantity,
                        JobsPerMontPerOperator = maxNumberJobsPerOperatorInMonth
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

        public List<WorkLoad> GetWorkLoads() => JsonService.LoadJson<WorkLoad>("/Data/WorkLoad.json");

        public bool SaveWorkLoad(List<WorkLoad> workLoads)
        {

            try
            {
                JsonService.SaveJson<WorkLoad>(workLoads, "/Data/WorkLoad.json");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }


    }
}
