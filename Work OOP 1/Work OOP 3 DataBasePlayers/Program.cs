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

    class Player
    {
        public int id { get; private set; }
        public string name { get; private set; }
        public int level { get; private set; }
        public bool isBaned { get; private set; }

        public Player(int id, string name, int level, bool isBaned = false)
        {
            this.id = id;
            this.name = name;
            this.level = level;
            this.isBaned = isBaned;
        }

        public void Ban()
        {
            isBaned = true;
        }

        public void Unban()
        {
            isBaned = false;
        }
    }

    class DataBasePlaeyrs
    {
        private List<Player> players = new List<Player>();

        public void Add()
        {
            int result;
            int id = 0;
            int level = 0;
            bool isStringNumber;

            Console.WriteLine("Enter Id");
            isStringNumber = CheckString(out result);

            if(isStringNumber)
            {
                id = result;
            }
            else
            {
                Console.WriteLine("Error");
            }

            Console.WriteLine("Enter name");
            string name = Console.ReadLine();

            Console.WriteLine("Enter level");
            isStringNumber = CheckString(out result);

            if (isStringNumber)
            {
                level = result;
            }
            else
            {
                Console.WriteLine("Error");
            }

            players.Add(new Player(id, name, level));
        }

        private bool CheckString(out int result)
        {
            bool isStringNumber;

            string massege = Console.ReadLine();
            isStringNumber = int.TryParse(massege, out result);
            return isStringNumber;
        }

        public void Delite()
        {
            int result;
            int id = 0;
            bool isStringNumber;

            Console.WriteLine("Enter ID");
            isStringNumber = CheckString(out result);

            if (isStringNumber)
            {
                id = result;
            }
            else
            {
                Console.WriteLine("Error");
            }

            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].id == id)
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
                if (players[i].id == id)
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
                if (players[i].id == id)
                {
                    players[i].Unban();
                }
            }
        }

        public void ShowInfo()
        {
            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine($"ID {players[i].id}\nName {players[i].name}\nLevel {players[i].level}\n" +
                    $"Ban status {players[i].isBaned}\n ");
            }
        }
    }
}
