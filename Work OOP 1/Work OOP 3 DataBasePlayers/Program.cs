using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBasePlaeyrs dataBasePlaeyrs = new DataBasePlaeyrs();

            bool dataBaseIsWork = true;

            while (dataBaseIsWork)
            {
                Console.WriteLine("Enter Add, Show, Baned, Unbaned, Delete, Esc\n");

                string comand = Console.ReadLine();

                if (comand == "Add")
                {
                    dataBasePlaeyrs.Add();
                }
                else if (comand == "Show")
                {
                    dataBasePlaeyrs.ShowInfo();
                }
                else if (comand == "Baned")
                {
                    dataBasePlaeyrs.Baned();
                }
                else if (comand == "Unbaned")
                {
                    dataBasePlaeyrs.UnBaned();
                }
                else if (comand == "Delete")
                {
                    dataBasePlaeyrs.Delite();
                }
                else if (comand == "Esc")
                {
                    dataBaseIsWork = false;
                }
            }
        }
    }

    class DataBasePlaeyrs
    {
        private List<Player> players = new List<Player>();

        public void Add()
        {
            Console.WriteLine("Enter Id");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter level");
            int level = Convert.ToInt32(Console.ReadLine());

            players.Add(new Player(id, name, level));
        }

        public void Delite()
        {
            Console.WriteLine("Enter ID");
            int id = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].Id == id)
                {
                    players.RemoveAt(i);
                }
            }
        }

        public void Baned()
        {
            Console.WriteLine("Enter ID");
            int id = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].Id == id)
                {
                    players[i].Ban();
                }
            }
        }

        public void UnBaned()
        {
            Console.WriteLine("Enter ID");
            int id = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].Id == id)
                {
                    players[i].Unban();
                }
            }
        }

        public void ShowInfo()
        {
            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine($"ID {players[i].Id}\nName {players[i].Name}\nLevel {players[i].Level}\n" +
                    $"Ban status {players[i].PlayerIsBaned}\n ");
            }
        }

    }
    class Player
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Level { get; private set; }
        public bool PlayerIsBaned { get; private set; }

        public Player(int id, string name, int level, bool playerIsBaned = false)
        {
            Id = id;
            Name = name;
            Level = level;
            PlayerIsBaned = playerIsBaned;
        }

        public void Ban()
        {
            PlayerIsBaned = true;
        }

        public void Unban()
        {
            PlayerIsBaned = false;
        }
    }
}
