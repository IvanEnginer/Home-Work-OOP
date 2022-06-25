using System;
using System.Collections.Generic;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Stroge strogeNarket = new Stroge();

            Visiter visiterOne = new Visiter(100);
            Visiter visiterTwo = new Visiter(50);
            Visiter visiterFree = new Visiter(20);

            Maneger maneger = new Maneger();

            visiterOne.AddItems(strogeNarket);
            visiterTwo.AddItems(strogeNarket);
            visiterFree.AddItems(strogeNarket);

            maneger.EnqueueToQueue(visiterOne);
            maneger.EnqueueToQueue(visiterTwo);
            maneger.EnqueueToQueue(visiterFree);

            maneger.WorkOutQueue();
        }
    }
     
    class Maneger
    {
        private Queue<Visiter> _visiters = new Queue<Visiter>();

        public void EnqueueToQueue(Visiter visiter)
        {
            _visiters.Enqueue(visiter);
        }

        public void WorkOutQueue()
        {
            while (_visiters.Count > 0)
            {
                GetVisiterChek(_visiters.Peek());
                _visiters.Dequeue();
                Console.WriteLine("Visiter Dequrue\n");
            }

            Console.WriteLine("\nQueue end");
        }

        public bool GetVisiterChek(Visiter visiter)
        {
            int solvency = CulculateTotal(visiter);

            if (solvency < visiter.Money)
            {
                visiter.WithdrawalMoney(solvency);
                Console.WriteLine($"OK. Total price {solvency}");
                Console.WriteLine($"Money visiter {visiter.Money}");
                return true;
            }
            else if (CheckMinimumPriceItem(visiter))
            {
                while (solvency > visiter.Money)
                {
                    visiter.IsOutItem();
                }

                Console.WriteLine("After withdrow items");
                visiter.WithdrawalMoney(solvency);
                Console.WriteLine($"OK. Total price {solvency}");
                Console.WriteLine($"Money visiter {visiter.Money}");
                return true;
            }
            else
            {
                Console.WriteLine("No Money");
                return false;
            }
        }

        public void DequeueToQueue()
        {
            _visiters.Dequeue();
        }

        private bool CheckMinimumPriceItem(Visiter visiter)
        {
            for (int i = 0; i < visiter.GetCountItems(); i++)
            {
                if (visiter.GetPriceItems(i) <= visiter.Money)
                {
                    return true;
                }
            }

            return false;
        }

        private int CulculateTotal(Visiter visiter)
        {
            int total = 0;
            int count = visiter.GetCountItems();

            for (int i = 0; i < count; i++)
            {
                total += visiter.GetPriceItems(i);
            }
            return total;
        }
    }

    class Stroge
    {
        private List<Item> _storege = new List<Item>() {new Item("apple", 10),
        new Item("radish", 15), new Item("carrots", 5), new Item("apricot", 20), 
        new Item("watermelon", 50)};

        private Random _random = new Random();

        public void GetItems(ref List<Item> items)
        {
            items.Add(new Item(_storege[_random.Next(0, _storege.Count)].Name, _storege[_random.Next(0, _storege.Count)].Price));
        }
    }

    class Visiter
    {
        public int Money { get; private set; }

        private List<Item> _items = new List<Item>();

        private Random _random = new Random();

        public Visiter(int money)
        {
            Money = money;
        }

        public void WithdrawalMoney(int chek)
        {
            Money -= chek;
        }

        public int GetPriceItems(int number)
        {
            return _items[number].Price;
        }

        public void AddItems(Stroge stroge)
        {
            int basketSize = 5;

            for (int i = 0; i < _random.Next(1, basketSize); i++)
            {
                stroge.GetItems(ref _items);
            }
        }

        public bool IsOutItem()
        {
            if (_items.Count > 0)
            {
                _items.RemoveAt(_random.Next(0, _items.Count));
                return true;
            }
                else 
                {
                    return false;
                }           
        }

        public int GetCountItems()
        {
            return _items.Count;
        }

        public void ShowManey()
        {
            Console.WriteLine($"Money: {Money}");
        }
    }
}

    class Item
    { 
        public int Price { get; private set; }
        public string Name { get; private set; }

        public Item(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public void Show()
        {
            Console.WriteLine($"Item name: {Name}, price {Price} ");
        }
}
