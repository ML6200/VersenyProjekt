using System;

namespace Infó_verseny
{

    class Program
    {
        static void Main(string[] args)
        {
            PoolClass Pool = new PoolClass(1, 80, 0.353, "gyongyok.txt");
            Pool.Start();

            Console.ReadKey();
        }
    }

    
}
