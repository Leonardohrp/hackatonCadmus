using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonsterTest.Models
{
    public class Inteiros
    {
        public Inteiros(){ }

        public Inteiros(int id, int numero1, int numero2, int numero3, int numero4, int numero5)
        {
            Id = id;
            this.numero1 = numero1;
            this.numero2 = numero2;
            this.numero3 = numero3;
            this.numero4 = numero4;
            this.numero5 = numero5;
        }

        public int Id { get; set; }
        public int numero1 { get; set; }
        public int numero2 { get; set; }
        public int numero3 { get; set; }
        public int numero4 { get; set; }
        public int numero5 { get; set; }

    }
}