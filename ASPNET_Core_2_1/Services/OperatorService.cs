using ASPNET_Core_2_1.Models;
using System.Collections.Generic;
using System.Linq;

namespace ASPNET_Core_2_1.Services
{
    public class OperatorService : IOperatorService
    {
        public List<Operator> CreateOperatorsList(int quantity)
        {
            var operators = new List<Operator>();
            for (var i = 1; i <= quantity; i++)
            {
                operators.Add(new Operator { Id = i });

            }

            return operators;
        }

        public List<Operator> AddOperator(List<Operator> operators)
        {
            var newOperator = new Operator
            {
                Id = operators.Count > 0 ? operators.Max(x => x.Id) + 1 : 1
            };
            operators.Add(newOperator);
            return operators;
        }
    }
}
