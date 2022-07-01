using System;
using System.Collections.Generic;

namespace Servise
{
    class Program
    {
        static void Main(string[] args)
        {
            Storage strorege1 = new Storage();

            strorege1.ShowStorege();
        }
    }

    class Storage
    {
        private Random _random = new Random();
        private List<Detail> _details = new List<Detail>();
        private Dictionary<Detail, int> _storage = new Dictionary<Detail, int>()
        {
            [new Detail("Колесо", 10)] = 10,
            [new Detail("Стекло", 5)] = 3,
            [new Detail("Фары", 2)] = 20,
            [new Detail("Бампер", 15)] = 30,
            [new Detail("Замок", 15)] = 15
        };



        public Storage()
        {
            _details.Add(new Detail("Колесо", 10));
        }

        public void ShowStorege()
        {
            Console.WriteLine("На складе");

            //for (int i = 0; i < _storage.Count; i++)
            //{
            //    Console.WriteLine(_storage.ContainsKey(new Detail("Колесо", 10)));
            //}
            Console.WriteLine(_storage[_details[0]]);
        }
    }

    class Detail
    {
        public string Name { get; private set; }
        public int Cost { get; private set; }

        public Detail(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }
    }
}