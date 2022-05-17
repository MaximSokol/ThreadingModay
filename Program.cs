using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadingModay
{
    class Program
    {

        // Task 1


        //public static int add;

        //public static void Reverse()
        //{
        //    Thread th = new Thread(Reverse);
        //    add++;
        //    th.Name = "Second" + add;
        //    Thread.Sleep(1000);
        //    th.Start();
        //    Console.WriteLine(Thread.CurrentThread.Name);
        //}


        // Taks 2

        static void Main(string[] args)
        {
            // Task 1.1


            //Thread th = new Thread(Reverse) { Name = "first" + add };
            //th.Start();


            // Task 2.1

            Matr mat;

            for (int i = 0; i < 30; i++)
            {
                mat = new Matr(i * 2);
                new Thread(mat.Move).Start();
            }
        }
    }
}
