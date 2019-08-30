using System;
using System.Collections.Generic;
using System.Linq;

namespace ASPNET_Core_2_1.Models
{
    public class Probabilidad
    {
        private List<Operator> _operators;

        public Probabilidad(List<Operator> operators)
        {
            _operators = operators;
        }

        public decimal media()
        {
            decimal salarioTotal = 0;
            var cantidadOperarios = _operators.Count;

            foreach (var op in this._operators)
            {
                salarioTotal += op.Salary;
            }

            return salarioTotal / cantidadOperarios;
        }

        public decimal mediana()
        {
            Operator operario1, operario2;
            var cantidadOperarios = _operators.Count;
            var mod = cantidadOperarios % 2;
            decimal mid;
            decimal salario1, salario2;

            var sortedList = this._operators.OrderBy(o => o.Salary).ToList();

            if (mod == 1)
            {
                mid = (cantidadOperarios - 1) / 2;
                operario1 = sortedList[(int)mid];
                return operario1.Salary;
            }
            else
            {
                mid = (cantidadOperarios) / 2;
                operario1 = sortedList[(int)mid];
                operario2 = sortedList[(int)mid - 1];

                salario1 = operario1.Salary;
                salario2 = operario2.Salary;

                return (salario1 + salario2) / 2;
            }
        }

        public decimal varianza()
        {
            var cantidadOperarios = this._operators.Count;
            double sum = 0;
            decimal var;

            foreach (var operario in this._operators)
            {
                sum += Math.Pow(((double)operario.Salary - (double)media()), 2);
            }
            var = (decimal)sum / cantidadOperarios;
            return var;
        }
    }
}
