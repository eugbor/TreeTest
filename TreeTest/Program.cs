using System;
using System.Linq;

namespace TreeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Tree tree = new Tree();
            var rnd = new Random();
            for (var i = 0; i < n; i++)
                tree.Add(i, rnd.Next(100));

            // Вывод дерева на консоль
            foreach (var pair in tree.GetView())
                Console.WriteLine("{0} : {1}", pair.Key, pair.Value);


            var value = int.Parse(Console.ReadLine());

            // Поиск значания (Левосторонний обход)
            var path = tree.Find(value);
            if (path.Any())
                Console.WriteLine(path);
            else
                Console.WriteLine("Не найдено");

            Console.ReadKey();
        }
    }
}
