using System;
using System.Collections.Generic;

namespace War
{
    class Program
    {
        static void Main(string[] args)
        {
            Sqwad sqwad = new Sqwad("A");
            Sqwad sqwad1 = new Sqwad("B");

            Battle battle = new Battle();

            bool isWork = true;

            while (isWork)
            {
                battle.HitsToSwqde(sqwad, sqwad1);
                battle.ShowSqades(sqwad1);
                battle.HitsToSwqde(sqwad1, sqwad);
                battle.ShowSqades(sqwad);

                if (battle.SqadeIsExist(sqwad))
                {
                    Console.WriteLine("Sqwade: " + sqwad1.Name + " WIN");
                    isWork = false;
                } 
                else if (battle.SqadeIsExist(sqwad1))
                {
                    Console.WriteLine("Sqwade: " + sqwad.Name + " WIN");
                    isWork = false;
                }
                else
                {
                    isWork = true;
                }
            }
        }
    }

    class Figther
    { 
        public int Number { get; private set; }
        public int Health { get; private set; }
        public int Damage { get; private set; }

        public Figther(int number, int health, int damage)
        {
            Number = number;
            Health = health;
            Damage = damage;
        }

        public void TakeDamage(int damageFigther)
        {
            Health -= damageFigther;
        }

        public void ShowHealth(int name)
        {
            Console.WriteLine("Name: " + name + ". Health: " + Health + ".");
        }
    }

    class Sqwad
    {
        private List<Figther> _fighters = new List<Figther>();

        public string Name { get; private set; }

        private int _size = 5;
        private int _minimumHealth = 30;
        private int _maximumHeaith = 150;
        private int _minimumDamage = 10;
        private int _maximumDamage = 50;
        private Random _random = new Random();

        public Sqwad(string name)
        {
            Name = name;

            Creat();
        }

        public void DamageToFighter(int i, int damage)
        {
            _fighters[i].TakeDamage(damage);
        }

        public void ShowFigters()
        {
            for (int i = 0; i < _fighters.Count; i++)
            {
                Console.WriteLine($"Name: {_fighters[i].Number}. Health: {_fighters[i].Health}." +
                    $" Damage: {_fighters[i].Damage}");
            }
        }

        public int RevealDamageFighterSqade(int number, Sqwad sqwade)
        {
            if (sqwade.GetCurrentSize() > 0)
            {
                return sqwade._fighters[number].Damage;
            }
            else
            {
                return 0;
            }
        }

        public bool IsOutFigheter(int name)
        {
            if (_fighters.Count > 0)
            {
                _fighters.RemoveAt(name);
                return true;
            }
            else
            {
                return false;
            }
        }

        public int TakeHelath(int number)
        {
            return _fighters[number].Health;
        }

        public void Creat()
        {
            for (int i = 0; i < _size; i++)
            {
                _fighters.Add(new Figther(i, CreatHealth(), CreatDamage()));
            }
        }

        public int GetCurrentSize()
        {
            return _fighters.Count;
        }

        private int CreatHealth()
        {
            return _random.Next(_minimumHealth, _maximumHeaith);
        }

        private int CreatDamage()
        {
            return _random.Next(_minimumDamage, _maximumDamage);
        }
    }

    class Battle
    {
        private Random _random = new Random();

        public Battle() { }

        public void ShowSqades(Sqwad sqwad)
        {
            Console.WriteLine("Sqade: " + sqwad.Name);
            sqwad.ShowFigters();
            Console.WriteLine();
        }

        public bool SqadeIsExist(Sqwad sqwad)
        {
            if (sqwad.GetCurrentSize() <= 0)
                return true;
            else
                return false;
        }

        public void HitsToSwqde(Sqwad sqwadAgressor, Sqwad sqwadAbsorber)
        {
            int target;

            for (int i = 0; sqwadAgressor.GetCurrentSize() > i; i++)
            {            
                target = _random.Next(0, sqwadAbsorber.GetCurrentSize());

                if (sqwadAbsorber.GetCurrentSize() > 0)
                {
                    sqwadAbsorber.DamageToFighter(target, sqwadAgressor.RevealDamageFighterSqade(i, sqwadAgressor));

                    if (sqwadAbsorber.TakeHelath(target) <= 0)
                    {
                        sqwadAbsorber.IsOutFigheter(target);
                    }
                }
            }
        }
    }
}
