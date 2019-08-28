using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET_Core_2_1
{
    public class Operario
    {

        private int id;
        private int cal;

        public int Id { get => id; set => id = value; }
        public int Cal { get => cal; set => cal = value; }

        public Operario(int ID)
        {
            Id = ID;
           
        }



    }
}
