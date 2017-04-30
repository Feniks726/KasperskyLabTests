using System;
using System.Collections.Generic;
using System.Linq;
using Task2.Content;
using Task2.Extensions;

namespace Task2
{
    class Program
    {

        public static ICollection<int> Collect = new List<int>();

        static void Main(string[] args)
        {

            //Запрашиваем число
            Console.Write(Messages.MessagesConstant.Number);

            var tmp = Console.ReadLine();
            int x;

            if (!int.TryParse(tmp, out x))
            {
                Console.Write(Messages.MessagesConstant.NumberException);
                Console.ReadLine();
                return;
            }

            //Запрашиваем разброс коллекции от введенного числа
            Console.Write(Messages.MessagesConstant.Scatter);

            tmp = Console.ReadLine();
            double scatter;

            if (!double.TryParse(tmp, out scatter))
            {
                Console.Write(Messages.MessagesConstant.NumberException.Format(tmp));
                Console.ReadLine();
                return;
            }


            //Запрашиваем размер коллекции
            Console.Write(Messages.MessagesConstant.SizeOfCollection);

            tmp = Console.ReadLine();
            int size;

            if (!int.TryParse(tmp, out size))
            {
                Console.Write(Messages.MessagesConstant.NumberException.Format(tmp));
                Console.ReadLine();
                return;
            }


            var random = new Random();
            Console.WriteLine(DateTime.UtcNow.ToString("yy-mm-dd HH:mm:ss:ms"));
            Console.WriteLine(Messages.MessagesConstant.CreationCollection);

            //Заполняем коллекцию случайными числами
            for (long i = 0; i < size; i++)
            {
                var y = random.Next((int)(scatter * x));
                Collect.Add(y);
            }

            Console.WriteLine(DateTime.UtcNow.ToString("yy-mm-dd HH:mm:ss:ms"));
            Console.WriteLine(Messages.MessagesConstant.ConvertToHashSet);

            //Преобразуем в хеш таблицу

            var table = Collect.ToHashSet();
            Console.WriteLine(DateTime.UtcNow.ToString("yy-mm-dd HH:mm:ss:ms"));

            //Предварительное получение результирующего множества
            var intermediateResult = table.Where(t => t < x);
            //Нахождение пар результирующего множества
            Console.WriteLine(Messages.MessagesConstant.FindResult);
            var res = new List<PairOfResults>();

            foreach (
                var c in
                    intermediateResult.Where(c => intermediateResult.Any(r => r == (x - c)))
                        .Where(c => !(res.Any(r1 => Equals(r1.Value1, c) || res.Any(r2 => Equals(r2.Value2, c))))))
            {
                res.Add(new PairOfResults(c, x - c));
            }


            Console.WriteLine(DateTime.UtcNow.ToString("yy-mm-dd HH:mm:ss:ms"));

            //Выводим результат
            Console.WriteLine();
            Console.Write(Messages.MessagesConstant.ThePairOfResults);
            Console.WriteLine();
            if (res.Any())
            {
                foreach (var c in res)
                {
                    Console.WriteLine($"{c.Value1} : {c.Value2} ");
                }
            }
            else
            {
                Console.Write(Messages.MessagesConstant.NoResult);
            }
            Console.WriteLine();
            Console.WriteLine(DateTime.UtcNow.ToString("yy-mm-dd HH:mm:ss:ms"));

            Console.ReadLine();
        }
    }
}
