using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET_Core_2_1
{
    public class Calificacion
    {
        public List<int> operarios;

        

        //Creando indices para control de lista de operarios
        private int index;
        private int index2;

        public Calificacion()
        {
          
        }

        //metodo calificar recibiendo como parametro "num" que representa numero de operarios
        public void Calificar(int num)
        {
            //creando lista tomando como rango 0 a num

            List<int> Operario = new List<int>();

            for (int j = 0; j < num; j++)
            {
                Operario.Add(j);
            }

            //Clonando lista para usarla en division de operarios por calificación
            List<int> OperarioClon = new List<int>(Operario);

            //obtener el 2% de operarios que tendran calificacion de "1" aplicando round para evitar fraccion de operarios
            double cal1 = num * 0.02;
            Math.Round(cal1);

            //obtener el 8% de operarios que tendran calificacion de "2 ó 3"
            double cal2 = num * 0.08;
            Math.Round(cal2);

            //obtener los operarios que tendran calificacion de "4 ó 5"
            double cal3 = num - cal1 - cal2;

            
           //tomando numero de operarios del 2% de forma random para ser un sistema justo
            for (int i = 0;i< cal1;i++)
            {
                Random r1 = new Random();
                index = r1.Next(num);
                Operario ObjetoOperario = new Operario(index);
                ObjetoOperario.Cal = 1;
                OperarioClon.RemoveAt(index);

            }

            //tomando numero de operarios del 8% de forma random para ser un sistema justo
            for (int i = 0; i < cal2; i++)
            {
                Random r1 = new Random();
                index2 = r1.Next(num);
            //tomando random para evaluar si operario recibe calificación 2 ó 3
                Random r2 = new Random();
                index2 = r1.Next(2,3);
            //Creando objetos operario con su respectiva calificación
                if (index2==2)
                {
                    Operario ObjetoOperario = new Operario(index);
                    ObjetoOperario.Cal = 2;
                }
                else
                {
                    Operario ObjetoOperario = new Operario(index);
                    ObjetoOperario.Cal = 3;
                }
                OperarioClon.RemoveAt(index);

                }
            //tomando random para evaluar si operario recibe calificación 4 ó 5
            for (int i = 0; i < cal3; i++)
            {
                Random r1 = new Random();
                index2 = r1.Next(num);

                Random r2 = new Random();
                index2 = r1.Next(4, 5);

                if (index2 == 4)
                {
                    Operario ObjetoOperario = new Operario(index);
                    ObjetoOperario.Cal = 4;
                }
                else
                {
                    Operario ObjetoOperario = new Operario(index);
                    ObjetoOperario.Cal = 5;
                }
                OperarioClon.RemoveAt(index);

            }
 
            
        }
    }
}




