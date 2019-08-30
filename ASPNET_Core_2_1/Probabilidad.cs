using System;
using System.Collections.Generic;

namespace ASPNET_Core_2_1.Models
{
    public class Probabilidad
    {
        private List<Operator> operarios;

        public Probabilidad(List<Operator> opeararios)
        {
            this.operarios = opeararios;
        }

        public decimal media()
        {
            decimal salarioTotal = 0;
            int cantidadOperarios = operarios.Count;

            foreach (var operario in this.operarios)
            {
                salarioTotal += operario.Salary;
            }

            return salarioTotal / cantidadOperarios;
        }

        public decimal mediana()
        {
            Operator operario1, operario2;
            int cantidadOperarios = operarios.Count;
            int mod = cantidadOperarios % 2;
            decimal mid;
            decimal salario1, salario2;

            List<Operator> sortedList = this.operarios.OrderBy(o => o.Salary).ToList();

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
            int cantidadOperarios = this.operarios.Count;
            double sum = 0;
            decimal var;

            foreach (var operario in this.operarios)
            {
                sum = sum + Math.Pow(((double)operario.Salary - (double)media()), 2);
            }

            var = (decimal)sum / cantidadOperarios;

            return var;
        }
    }
}
