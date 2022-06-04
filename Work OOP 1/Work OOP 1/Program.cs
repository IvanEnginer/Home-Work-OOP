using System;

namespace Work_OOP_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Fighter fighterOne = new Fighter(100, 100, 100, 100);

            fighterOne.ShowStates();
        }

        class Fighter
        {
            private int _health;
            private int _armore;
            private int _damege;
            private int _dexterity;

            public Fighter(int health, int armore, int damege,int dexterity)
            {
                this._health = health;
                this._armore = armore;
                this._damege = damege;
                this._dexterity = dexterity;
            }

            public void ShowStates()
            {
                Console.WriteLine($" Health {_health} \n Armore {_armore} \n Damege {_damege} \n Dexterity {_dexterity}");
            }
        }
    }
}
