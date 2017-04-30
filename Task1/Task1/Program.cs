using System;
using System.Linq;
using System.Threading;

namespace Task1
{
    class Program
    {

        static void Main(string[] args)
        {
            var rnd=new Random();
            while (true)
            {

                new Thread(() => Console.WriteLine(Pop<int>())).Start();
                new Thread(() => Push(rnd.Next(int.MaxValue))).Start();
                Thread.Sleep(100);
            }
        }

        static T Pop<T>()
        {
            try
            {
                while (!Server<T>.Qe.Any())
                {
                    Thread.Sleep(100);
                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            lock (Server<T>.Qe)
            {
                return Server<T>.Qe.Dequeue();
            }
        }

        static void Push<T>(T t)
        {
            lock (Server<T>.Qe)
            {
                Server<T>.Qe.Enqueue(t);
            }
        }
    }
}
