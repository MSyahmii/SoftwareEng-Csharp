using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace asynchronous
{
    class Program
    {

        static bool done;
        //Thread safety
        static readonly object tupperware = new object();
        static void Main(string[] args)
        {
            //Thread t1 = new Thread(WriteY);
            //t1.Start();
            //WriteX();

            new Thread(Go).Start();
            new Thread(Go).Start();


            Console.Read();
        }

        static void Go()
        {
            lock (tupperware)
            {
                if (!done)
                {
                    Console.WriteLine("Done");
                    done = true;
                }
            }
        }

        static void WriteX()
        {
            for (int i = 0; i < 50; i++)
            {
                Console.Write("x");
            }
        }
        static void WriteY()
        {
            for (int i = 0; i < 50; i++)
            {
                Console.Write("y");
            }
        }
    }

    
}
