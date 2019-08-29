using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET_Core_2_1.Models
{
    public class Probabilidad
    {
        private List<Operator> operarios;

        Probabilidad(List<Operator> opeararios)
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

            return salarioTotal / Convert.ToDecimal(cantidadOperarios);
        }

        public decimal mediana()
        {
            Operator operario1, operario2;
            int cantidadOperarios = operarios.Count;
            int mod = cantidadOperarios % 2;
            decimal salario1, salario2;

            if (mod == 1)
            {
                operario1 = this.operarios[mod + 1];
                return operario1.Salary;
            }
            else
            {
                operario1 = this.operarios[mod];
                operario2 = this.operarios[mod + 1];

                salario1 = operario1.Salary;
                salario2 = operario2.Salary;

                return (salario1 + salario2) / 2;
            }
        }

        public decimal varianza()
        {
            int cantidadOperarios = this.operarios.Count;
            double sum = 0;
            decimal op;

            foreach(var operario in this.operarios)
            {
                op = operario.Salary - media();
                sum = sum + Math.Pow(Convert.ToDouble(op), 2);
            }

            return Convert.ToDecimal(sum / (cantidadOperarios - 1));
        }
    }
}
