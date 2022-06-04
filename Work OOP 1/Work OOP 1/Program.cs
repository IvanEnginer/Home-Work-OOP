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
            private int Health;
            private int Armore;
            private int Damege;
            private int Dexterity;

            public Fighter(int health, int armore, int damege,int dexterity)
            {
                Health = health;
                Armore = armore;
                Damege = damege;
                Dexterity = dexterity;
            }

            public void ShowStates()
            {
                Console.WriteLine($" Health {Health} \n Armore {Armore} \n Damege {Damege} \n Dexterity {Dexterity}");
            }
        }
    }
}
