using System;
using System.Collections.Generic;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            Player plaerOne = new Player(200);
            Seller sellerOne = new Seller();

            string comand;

            //           sellerOne.Show();

            //           Console.WriteLine("-------");

            //           string name = Console.ReadLine();

            ////           plaerOne.GetItem(name, sellerOne);

            //           plaerOne.ShowItems();



            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine("Menu\n" +
                    "Enter - Show - for watch saller items\n" +
                    "Enter - Bay - for bay items\n" +
                    "Enter - Bag - for watch your bag\n" +
                    "Enter - Esc - for exit");

                Console.Write("Enter comand: ");

                comand = Console.ReadLine();

                switch (comand)
                {
                    case "Show":
                        ShowSellerItems(sellerOne);
                        break;
                    case "Bay":
                        BayItems(plaerOne, sellerOne);
                        break;
                    case "Bag":
                        ShowPlayerItems(plaerOne);
                        break;
                    case "Esc":
                        isWork = false;
                        break;
                }
            }

            static void ShowSellerItems(Seller seller)
            {
                seller.Show();
            }

            static void ShowPlayerItems(Player player)
            {
                player.ShowItems();
                Console.ReadKey();
                Console.Clear();
            }

            static void BayItems(Player player, Seller seller)
            {
                Console.Write("Enter name item: ");
                string name = Console.ReadLine();
                player.GetItem(name, seller);
                Console.Clear();
            }
        }
    }

    class Item
    {
        public string Name { get; private set; }
        public int Price { get; private set; }

        public Item(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }

    class Seller
    {
        private List<Item> _items = new List<Item>()
        {
            new Item("apple", 2), new Item("sword", 50), new Item("mace", 100)
        };

        public Seller() { }

        public bool TryGetItem(string name, int money, out Item item)
        {
            for (int i = 0; i < _items.Count; i++)
            {
                if (_items[i].Name == name)
                {
                    if (money > _items[i].Price)
                    {
                        item = _items[i];
                        _items.Remove(item);
                        return true;
                    }
                    else
                    {
                        item = null;
                        return false;
                    }
                }
            }
            item = null;
            return false;
        }

        public void Show()
        {
            for (int i = 0; i < _items.Count; i++)
                Console.WriteLine(_items[i].Name + " price: " + _items[i].Price);
        }
    }

    class Player
    {
        private List<Item> _items = new List<Item>();

        public int Money { get; private set; }

        public Player(int money)
        {
            Money = money;
        }

        public void GetItem(string name, Seller seller)
        {
            if (seller.TryGetItem(name, Money, out Item item))
            {
                _items.Add(item);
            }
            else
            {
                Console.WriteLine("False");
            }
        }

        public void ShowItems()
        {
            for (int i = 0; i < _items.Count; i++)
            {
                Console.WriteLine($"In Player bag {_items[i].Name}");
            }
        }
    }
}
