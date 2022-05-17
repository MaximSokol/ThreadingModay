using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadingModay
{
    class Matr
    {
        public readonly object locker = new object(); // The object of synchronous access
        //---------------------------------------------

        Random rand;
        const string litters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        //---------------------------------------------------------------

        public int Count { get; set; }
        //-------------------------------

        public Matr(int count)
        {
            this.Count = count;
            rand = new Random((int)DateTime.Now.Ticks);
        }
        //------------------------

        public char GetChar()
        {
            return litters.ToCharArray()[rand.Next(0, 35)];
        }
        //------------------------

        public void Move()
        {
            int length;
            int count;
            while (true)
            {
                count = rand.Next(3, 6);
                length = 0;
                Thread.Sleep(rand.Next(50, 5000));
                for(int i = 0; i < 40; i++)
                {
                    lock (locker)
                    {
                        Console.CursorTop = 0;
                        Console.ForegroundColor = ConsoleColor.Black;
                        for(int j = 0; j < i; j++)
                        {
                            Console.CursorLeft = Count;
                            Console.WriteLine("█");
                        }
                        if (length < count)
                            length++;
                        else
                            if (length == count)
                            count = 0;
                        if (39 - i < length)
                            length--;
                        Console.CursorTop = i - length + 1;
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        for(int z = 0; z < length; z++)
                        {
                            Console.CursorLeft = Count;
                            Console.WriteLine(GetChar());
                        }
                        if(length >= 2)
                        {
                            Console.CursorLeft = Count;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(GetChar());
                        }
                        if(length >= 1)
                        {
                            Console.CursorLeft = Count;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(GetChar());
                        }
                        Thread.Sleep(20);
                    }
                }
            }

        }
    }
}
