using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET_Core_2_1
{
    public class Calificacion
    {
        public List<int> operarios;

        public Calificacion(List<int> Operarios)
        {
            Operarios = operarios;
        }

        //metodo calificar recibiendo como parametro la lista de operarios
        public double Calificar(List<int> Operario)
        {
            //Obteniendo numero de operarios en la lista 
            int num = Operario.Count;

            //obtener el 2% de operarios que tendran calificacion de "1" aplicando round para evitar fraccion de operarios
            double cal1 = num * 0.02;
            Math.Round(cal1);

            //obtener el 8% de operarios que tendran calificacion de "2 ó 3"
            double cal2 = num * 0.08;
            Math.Round(cal2);

            //obtener los operarios que tendran calificacion de "4 ó 5"
            double cal3 = num - cal1 - cal2;






            return ;
            
        }
    }
}




