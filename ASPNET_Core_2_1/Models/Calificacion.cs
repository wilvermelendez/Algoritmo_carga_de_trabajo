using ASPNET_Core_2_1.Models;
using System;
using System.Collections.Generic;

namespace ASPNET_Core_2_1
{
    public class Calificacion
    {
        // public List<int> operarios;



        //Creando indices para control de lista de operarios
        private int index;
        private int index2;
        private int index3;
        public int num;
        public int cont;
        Operator obj1 = new Operator();
        Operator obj5 = new Operator();
        Operator obj3 = new Operator();

   
        public Calificacion()
        {

        }


        //recibiendo lista de operarios a traves de parametro y contando el numero de operarios de la lista para proceder a clasificarlos para evaluar sus trabajos
        public void Calificar(List<Operator> Operario)
        {

            //Clonando lista para usarla en division de operarios por calificación
            List<Operator> OperarioClon = new List<Operator>(Operario);
            num = OperarioClon.Count;

           
            //obtener el 2% de operarios que tendran calificacion de "1" aplicando round para evitar fraccion de operarios
            double cal1 = num * 0.02;
            Math.Round(cal1);

            //obtener el 8% de operarios que tendran calificacion de "2 ó 3"
            double cal2 = num * 0.08;
            Math.Round(cal2);

            //obtener los operarios que tendran calificacion de "4 ó 5"
            double cal3 = num * 0.9;


            //tomando numero de operarios del 2% de forma random para ser un sistema justo
            for (int i = 0; i < cal1; i++)
            {
                num = OperarioClon.Count;
                Random r1 = new Random();
                index = r1.Next(num);
               
                 
                List<Jobs> lisop = new List<Jobs>();                                  //creando lista para almacenar los trabajos

                foreach (Operator obj in Operario)                                     //for each para guardar todos los trabajos en la lista confirmando que pertencen al mismo id
                {
                    if (obj.Id == index)
                    {
                        lisop = obj.Trabajos;
                        cont = lisop.Count;                                           //contador de los trabajos del usuario en cuestion

                        for (int z = 0; z < cont; z++)                               //codigo de evaluación de trabajos donde al primer ytrabajo se le asigna "1" y los demas una nota random de 1 a 5
                        {
                            if (lisop[0].Score == 1)
                            {
                                lisop[z].Score = r1.Next(1, 5);

                            }
                            else
                            {
                                lisop[0].Score = 1;
                            }

                        }
                    }



                }


                foreach (Operator obj2 in OperarioClon)                                  //borrando objeto de la lista clon para no evaluarlo nuevamente
                {
                    if (obj2.Id == index)
                    {
                        obj1 = obj2;
                    }
                }
                OperarioClon.Remove(obj1);
             

              
            }
            //tomando numero de operarios del 8% de forma random para ser un sistema justo
            for (int i = 0; i < cal2; i++)
            {
                num = OperarioClon.Count;
                Random r1 = new Random();
                index2 = r1.Next(num);
                //tomando random para evaluar si operario recibe calificación 2 ó 3
                Random r2 = new Random();
                index3 = r1.Next(2, 3);

                List<Jobs> lisop2 = new List<Jobs>();

                foreach (Operator obj in OperarioClon)
                {
                    obj.Id = index;
                    lisop2 = obj.Trabajos;
                }

                //Contando la lista de trabajos
                cont = lisop2.Count;

                //Creando objetos operario con su respectiva calificación

                if (index3 == 2)
                {
                    for (int z = 0; z < cont; z++)
                    {
                        if (lisop2[0].Score == 2)
                        {
                            lisop2[z].Score = r1.Next(2, 5);

                        }
                        else
                        {
                            lisop2[0].Score = 2;
                        }
                    }

                }
                else
                {
                    for (int z = 0; z < cont; z++)
                    {
                        if (lisop2[0].Score == 3)
                        {
                            lisop2[z].Score = r1.Next(2, 5);

                        }
                        else
                        {
                            lisop2[0].Score = 3;
                        }
                    }
                }

                foreach (Operator obj4 in OperarioClon)
                {
                    obj4.Id = index2;
                    obj3 = obj4;
                }


                OperarioClon.Remove(obj3);
                

            }



            //tomando random para evaluar si operario recibe calificación 4 ó 5
            for (int i = 0; i < cal3; i++)
            {
                num = OperarioClon.Count;
                Random r1 = new Random();
                index = r1.Next(num);

                List<Jobs> lisop3 = new List<Jobs>();

                foreach (Operator obj in OperarioClon)
                {
                    obj.Id = index;
                    lisop3 = obj.Trabajos;
                    //Contando la lista de trabajos
                    cont = lisop3.Count;

                    //Creando objetos operario con su respectiva calificación
                    for (int z = 0; z < cont; z++)
                    {
                        if (lisop3[0].Score == 5)
                        {
                            lisop3[z].Score = r1.Next(4, 5);

                        }
                        else
                        {
                            lisop3[0].Score = 5;
                        }
                    }
                }

                foreach (Operator obj6 in OperarioClon)
                {
                    obj6.Id = index;
                    obj5 = obj6;
                }
                OperarioClon.Remove(obj5);



               

            }

           
        }
    }
}




