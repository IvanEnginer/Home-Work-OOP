using System;
using System.Collections.Generic;

namespace War
{
    class Program
    {
        static void Main(string[] args)
        {
            Squad squad = new Squad("A");
            Squad squad1 = new Squad("B");

            Battle battle = new Battle();

            bool isWork = true;

            while (isWork)
            {
                isWork = battle.IsBattleRun(squad, squad1);
            }
        }
    }

    class Figther
    { 
        public int Id { get; private set; }
        public int Health { get; private set; }
        public int Damage { get; private set; }

        public Figther(int number, int health, int damage)
        {
            Id = number;
            Health = health;
            Damage = damage;
        }

        public void TakeDamage(int damageFigther)
        {
            Health -= damageFigther;
        }

        public void ShowInfo(int id)
        {
            Console.WriteLine("Name: " + id + ". Health: " + Health + ".");
        }
    }

    class Squad
    {
        private List<Figther> _fighters = new List<Figther>();

        private int _size = 5;
        private int _minimumHealth = 30;
        private int _maximumHeaith = 150;
        private int _minimumDamage = 10;
        private int _maximumDamage = 50;
        private Random _random = new Random();

        public string Name { get; private set; }

        public Squad(string name)
        {
            Name = name;

            Creat();
        }

        public void DamageToFighter(int position, int damage)
        {
            _fighters[position].TakeDamage(damage);
        }

        public void ShowFigters()
        {
            for (int i = 0; i < _fighters.Count; i++)
            {
                Console.WriteLine($"ID: {_fighters[i].Id}. Health: {_fighters[i].Health}." +
                    $" Damage: {_fighters[i].Damage}");
            }
        }

        public int RevealDamageFighterSqade(int number, Squad squad)
        {
            if (squad.GetCurrentSize() > 0)
            {
                return squad._fighters[number].Damage;
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

        public void ShowSqades(Squad squad)
        {
            Console.WriteLine("Sqade: " + squad.Name);
            squad.ShowFigters();
            Console.WriteLine();
        }

        public bool IsSqadeExist(Squad squad)
        {
            if (squad.GetCurrentSize() <= 0)
                return true;
            else
                return false;
        }

        public void HitsToSwqde(Squad squadAgressor, Squad squadAbsorber)
        {
            int target;

            for (int i = 0; squadAgressor.GetCurrentSize() > i; i++)
            {            
                target = _random.Next(0, squadAbsorber.GetCurrentSize());

                if (squadAbsorber.GetCurrentSize() > 0)
                {
                    squadAbsorber.DamageToFighter(target, squadAgressor.RevealDamageFighterSqade(i, squadAgressor));

                    if (squadAbsorber.TakeHelath(target) <= 0)
                    {
                        squadAbsorber.IsOutFigheter(target);
                    }
                }
            }
        }

        public bool IsBattleRun(Squad squad, Squad squad1)
        {
            while (!IsSqadeExist(squad) && !IsSqadeExist(squad1))
            {
                HitsToSwqde(squad, squad1);
                ShowSqades(squad1);
                HitsToSwqde(squad1, squad);
                ShowSqades(squad);
            }           

            if (IsSqadeExist(squad))
            {
                Console.WriteLine("Squad: " + squad1.Name + " WIN");
                return false;
            }
            else if (IsSqadeExist(squad1))
            {
                Console.WriteLine("Squad: " + squad.Name + " WIN");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
