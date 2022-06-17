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
                player.AddItemInBag(name, seller);
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

    class Person
    {
        protected List<Item> items = new List<Item>();
    }

    class Seller : Person
    {
        public Seller()
        {
            items.Add(new Item("apple", 2));
            items.Add(new Item("sword", 50));
            items.Add(new Item("mace", 100));
        }

        public bool TryGetItem(string name, out Item item, int money)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Name == name)
                {
                    if (money > items[i].Price)
                    {

                        item = items[i];
                        items.Remove(item);
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
            for (int i = 0; i < items.Count; i++)
                Console.WriteLine(items[i].Name + " price: " + items[i].Price);
        }
    }

    class Player : Person
    {
        public int Money { get; private set; }

        public Player(int money)
        {
            Money = money;
        }

        public void AddItemInBag(string name, Seller seller)
        {
            if (seller.TryGetItem(name, out Item item, Money))
            {
                items.Add(item);
                Money -= item.Price;
            }
            else
            {
                Console.WriteLine("False");
            }
        }

        public void ShowItems()
        {
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"In Player bag {items[i].Name}");
            }
        }
    }
}
