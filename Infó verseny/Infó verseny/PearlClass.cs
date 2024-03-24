using System;

namespace Infó_verseny
{
    class PearlClass
    {
        static public double limit = 0;
        static public int idcount = 0;
        public int id;
        public int x;
        public int y;
        public int z;
        public double value;


        public PearlClass(int x, int y, int z, int value)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.value = value;
            this.id = idcount;
            idcount++;
        }

        public double Distance(PearlClass obj) //Kiszámitja egy másik gyöngytől való távolságot
        {
            return Math.Sqrt(Math.Pow(obj.x - this.x, 2) + Math.Pow(obj.y - this.y, 2) + Math.Pow(obj.z - this.z, 2));
        }

        public double Quotiens(PearlClass obj) //Kiszámolja az ,,árértékarányt", ami a cél gyöngy távolságának és értékének a hányadosa
        {
            return this.value / this.Distance(obj); ;
        }
    }
}
