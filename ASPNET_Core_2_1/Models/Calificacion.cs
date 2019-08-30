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
        public Calificacion()
        {

        }


        //recibiendo lista de operarios a traves de parametro y contando el numero de operarios de la lista para proceder a clasificarlos para evaluar sus trabajos
        public void Calificar(List<Operator> Operario)
        {




            /*
            for (int j = 0; j < num; j++)
            {
                Operario.Add(j);
            }
            */


            //Clonando lista para usarla en division de operarios por calificación
            List<Operator> OperarioClon = new List<Operator>(Operario);


            //obtener el 2% de operarios que tendran calificacion de "1" aplicando round para evitar fraccion de operarios
            double cal1 = num * 0.02;
            Math.Round(cal1);

            //obtener el 8% de operarios que tendran calificacion de "2 ó 3"
            double cal2 = num * 0.08;
            Math.Round(cal2);

            //obtener los operarios que tendran calificacion de "4 ó 5"
            double cal3 = num - cal1 - cal2;


            //tomando numero de operarios del 2% de forma random para ser un sistema justo
            for (int i = 0; i < cal1; i++)
            {
                num = OperarioClon.Count;
                Random r1 = new Random();
                index = r1.Next(num);
                //Creando un objeto de tipo operador para acceder a su lista de trabajos respectiva
                Operator obj = new Operator(index);

                //A partir del operador crear una lista de sus trabajos
                List<Jobs> jbs = new List<Jobs>(obj.Trabajos);

                //Contando la lista de trabajos
                cont = jbs.Count;

                /*Creación de un bucle que evalue los trabajos, cumpliendo que este operador por ser parte del 2% tendra que tener la calificación de "1" en uno de sus trabajos en este caso 
                  en su primer trabajo, el algoritmo evalua si tiene nota de "1" en su primer trabajo si ese es el caso entonces toma la posicion Z que se esta evaluando y le asigna una nota
                  random entre 1 y 5, en el caso que sea la primera vez q se evalue el bucle y el trabajador aun no tenga 1 de nota en su primer trabajo entonces se le agrega la calificación de "1" sino se asigna la nota
                  entre "1 a 5" de manera random asi de esta forma si obtiene "1" por segunda vez, será por el algoritmo respetando que el operario este bajo un sistema justo*/
                for (int z = 0; z < cont; z++)
                {
                    if (jbs[0].Score == 1)
                    {
                        jbs[z].Score = r1.Next(1, 5);

                    }
                    else
                    {
                        jbs[0].Score = 1;
                    }
                }

                //se remueve el operario de la lista que se copió de la lista de operadores para no evaluar sus trabajos nuevamente y se tome un operador que no ha sido evaluado

                OperarioClon.RemoveAt(index);

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

                //Creando un objeto de tipo operador para acceder a su lista de trabajos respectiva
                Operator obj1 = new Operator(index2);

                //A partir del operador crear una lista de sus trabajos
                List<Jobs> jbs1 = new List<Jobs>(obj1.Trabajos);

                //Contando la lista de trabajos
                cont = jbs1.Count;

                //Creando objetos operario con su respectiva calificación

                if (index3 == 2)
                {
                    for (int z = 0; z < cont; z++)
                    {
                        if (jbs1[0].Score == 2)
                        {
                            jbs1[z].Score = r1.Next(2, 5);

                        }
                        else
                        {
                            jbs1[0].Score = 2;
                        }
                    }

                }
                else
                {
                    for (int z = 0; z < cont; z++)
                    {
                        if (jbs1[0].Score == 3)
                        {
                            jbs1[z].Score = r1.Next(2, 5);

                        }
                        else
                        {
                            jbs1[0].Score = 3;
                        }
                    }
                }
                OperarioClon.RemoveAt(index2);

            }



            //tomando random para evaluar si operario recibe calificación 4 ó 5
            for (int i = 0; i < cal3; i++)
            {
                num = OperarioClon.Count;
                Random r1 = new Random();
                index2 = r1.Next(num);

                //Creando un objeto de tipo operador para acceder a su lista de trabajos respectiva
                Operator obj2 = new Operator(index2);

                //A partir del operador crear una lista de sus trabajos
                List<Jobs> jbs2 = new List<Jobs>(obj2.Trabajos);

                //Contando la lista de trabajos
                cont = jbs2.Count;

                //Creando objetos operario con su respectiva calificación
                for (int z = 0; z < cont; z++)
                {
                    if (jbs2[0].Score == 5)
                    {
                        jbs2[z].Score = r1.Next(4, 5);

                    }
                    else
                    {
                        jbs2[0].Score = 5;
                    }
                }

                OperarioClon.RemoveAt(index2);

            }


        }
    }
}




