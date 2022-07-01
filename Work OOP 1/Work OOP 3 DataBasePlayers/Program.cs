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
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Level { get; private set; }
        public bool IsBaned { get; private set; }

        public Player(int id, string name, int level, bool isBaned = false)
        {
            Id = id;
            Name = name;
            Level = level;
            IsBaned = isBaned;
        }

        public void Ban()
        {
            IsBaned = true;
        }

        public void Unban()
        {
            IsBaned = false;
        }
    }

    class DataBasePlaeyrs
    {
        private List<Player> _players = new List<Player>();

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

            _players.Add(new Player(id, name, level));
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
            if (TryGetPlayer(out int id))
            {
                _players.RemoveAt(id);
            }
        }

        public void Baned()
        {
            if (TryGetPlayer(out int id))
            {
                _players[id].Ban();
            }
        }

        public void UnBaned()
        {
            if (TryGetPlayer(out int id))
            {
                _players[id].Unban();
            }
        }

        public void ShowInfo()
        {
            for (int i = 0; i < _players.Count; i++)
            {
                Console.WriteLine($"ID {_players[i].Id}\nName {_players[i].Name}\nLevel {_players[i].Level}\n" +
                    $"Ban status {_players[i].IsBaned}\n ");
            }
        }

        private bool TryGetPlayer(out int pointer)
        {
            Console.WriteLine("Enter ID");
            int id;

            if (int.TryParse(Console.ReadLine(), out id))
            {
                for (int i = 0; i < _players.Count; i++)
                {
                    if (_players[i].Id == id)
                    {
                        pointer = i;
                        return true;
                    }                    
                }
            }

            pointer = 0;
            Console.WriteLine("Error");
            return false;
        }
    }
}
