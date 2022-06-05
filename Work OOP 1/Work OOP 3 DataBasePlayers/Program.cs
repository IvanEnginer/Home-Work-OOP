using System;

namespace Work_OOP_3_DataBasePlayers
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBasePlaers[] players = { };

            bool IsUseDataBese = true;

            while (IsUseDataBese)
            {
                Console.WriteLine("Comand: \nAdd\nDelite\nBaned\nUnbaned\nShow Base\nEsc");

                string comand = Console.ReadLine();

                if(comand == "Add")
                {
                    DataBasePlaers[] temp = new DataBasePlaers[players.Length + 1];

                    for (int i = 0; i < players.Length; i++)
                    {
                        temp[i] = players[i];
                    }

                    Console.WriteLine("Enter name");
                    string name = Console.ReadLine();

                    Console.WriteLine("Enter id");
                    int id = Convert.ToInt32(Console.ReadLine());           

                    temp[temp.Length - 1] = new DataBasePlaers(id, name);

                    players = temp;

                }else if(comand == "Delite")
                {
                    Console.WriteLine("Enter ID for delite");
                    int id = Convert.ToInt32(Console.ReadLine());

                    DataBasePlaers[] temp = new DataBasePlaers[players.Length - 1];

                    for (int i = 0; i < players.Length; i++)
                    {
                        if(id != players[i].getID())
                            temp[i] = players[i];
                    }

                    players = temp;

                }
                else if(comand == "Baned")
                {
                    Console.WriteLine("Enter id");
                    int id = Convert.ToInt32(Console.ReadLine());

                    for (int i = 0; i < players.Length; i++)
                    {
                        if (id == players[i].getID())
                            players[i].BanedUnbanedPlayer("Baned");
                    }
                }
                else if(comand == "Unbaned")
                {
                    Console.WriteLine("Enter id");
                    int id = Convert.ToInt32(Console.ReadLine());

                    for (int i = 0; i < players.Length; i++)
                    {
                        if (id == players[i].getID())
                            players[i].BanedUnbanedPlayer("Unbaned");
                    }
                }
                else if(comand == "Show Base")
                {
                    for(int i =0; i < players.Length; i++)
                    {
                        players[i].ShowInfo();
                    }
                }
                else if(comand == "Esc")
                {
                    IsUseDataBese = false;
                }
            }
        }

        class Player
        {

        }

        class DataBasePlaers
        {
            private int _id;
            private string _name;
            private int _level;
            private bool _playerIsBaned;

            public DataBasePlaers(int id, string name)
            {
                _id = id;
                _name = name;
                _level = 1;
                _playerIsBaned = false;
            }

            public void AddPlayer(int id, string name)
            {
                _id = id;
                _name = name;
            }

            public void UpLevelPlayer(int level)
            {
                _level = level;
            }

            public void BanedUnbanedPlayer(string action)
            {
                if (action == "Baned")
                    _playerIsBaned = true;
                else if (action == "Unbaned")
                    _playerIsBaned = false;
            }

            public void ShowInfo()
            {
                Console.WriteLine($"ID {_id}\nName {_name}\nLevel {_level}\nBan status {_playerIsBaned}");
            }

            public int getID()
            {
                return _id;
            }
        }
    }
}
