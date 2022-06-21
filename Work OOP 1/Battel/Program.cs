using System;
using System.Collections.Generic;

namespace Battel
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isWork = true;

            Field field = new Field();

            field.TryCreatBattels();

            while (isWork)
            {
                field.Battle();
                isWork = field.ShowBattelResult();
            }
        }
    }

    class Fighter
    {
        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public int Damage { get; protected set; }

        public Fighter(string name, int heaith, int damage)
        {
            Name = name;
            Health = heaith;
            Damage = damage;
        }

        public void TakeDamage(int damageFighter)
        {
            Health -= damageFighter;

            Console.WriteLine(Name + " Hit " + damageFighter + " damage");
        }

        public void ShowHealth()
        {
            Console.WriteLine(Name + " Health: " + Health);
        }

        public void UseSpecialAttack()
        {
            Random random = new Random();
            int rangeMaximumNumbers = 100;
            int chance = random.Next(rangeMaximumNumbers);
            int chanceUsePower = 20;

            if (chance < chanceUsePower)
            {
                UsePower();
            }
        }

        protected virtual void UsePower() { }
    }

    class Field
    {
        private Fighter _fighterOne;
        private Fighter _fighterTwo;
        private List<Fighter> _fighters = new List<Fighter>();

        public void TryCreatBattels()
        {
            Console.WriteLine("Fighter 1");
            ChooseFigter(out _fighterOne);
            Console.WriteLine("Fighter 2");
            ChooseFigter(out _fighterTwo);
        }

        public Field()
        {
            _fighters.Add(new Boxer("Boxer One", 400, 30));
            _fighters.Add(new Boxer("Boxer Two", 350, 40));
            _fighters.Add(new KarateBoy("Karate Boy", 300, 25));
            _fighters.Add(new KarateBoy("Karate Man", 250, 35));
            _fighters.Add(new MMAFighter("Fighter", 150, 50));
        }

        public bool ShowBattelResult()
        {
            bool isWinerFound = true;
            if (_fighterOne.Health <= 0)
            {
                Console.WriteLine("Fighter " + _fighterTwo.Name + " WIN");
                isWinerFound = false;
            }
            else if (_fighterTwo.Health <= 0)
            {
                Console.WriteLine("Fighter " + _fighterOne.Name + " WIN");
                isWinerFound = false;
            }
            if (isWinerFound)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Battle()
        {
            _fighterOne.ShowHealth();
            _fighterTwo.ShowHealth();
            _fighterOne.TakeDamage(_fighterTwo.Damage);
            _fighterTwo.TakeDamage(_fighterOne.Damage);
            _fighterOne.UseSpecialAttack();
            _fighterTwo.UseSpecialAttack();
            Console.ReadKey();
            Console.Clear();
        }

        private void ChooseFigter(out Fighter fighter)
        {
            Show();
            Console.Write("Enter number fighter ");
            bool isNumber = int.TryParse(Console.ReadLine(), out int inputID);

            if (isNumber == false)
            {
                fighter = null;
            }
            else
            {
                fighter = _fighters[inputID - 1];
                _fighters.Remove(fighter);
                Console.WriteLine("Socefull");
            }
        }

        private void Show()
        {
            Console.WriteLine("list fighters");

            for (int i = 0; i < _fighters.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + "Name: " + _fighters[i].Name +
                   "Health: " + _fighters[i].Health + "Damage: " + _fighters[i].Damage);              
            }
        }
    }

    class Boxer : Fighter
    {
        private int _damageBoostTypeOne = 30;
        private int _damageBoostTypeTwo = 50;

        public Boxer(string name, int health, int damage) : base(name, health, damage) { }

        protected override void UsePower()
        {
            Random random = new Random();
            int rangeMaximumNumbers = 2;
            int chance = random.Next(rangeMaximumNumbers);

            if (chance == 1)
            {
                Console.WriteLine("Huck");
                Damage += _damageBoostTypeOne;
            }
            else
            {
                Console.WriteLine("Right");
                Damage += _damageBoostTypeTwo;
            }
        }
    }

    class KarateBoy : Fighter
    {
        public KarateBoy(string name, int health, int damage) : base(name, health, damage) { }

        protected override void UsePower()
        {
            Random random = new Random();
            int rangeMaximumNumbers = 6;
            int multiplication = random.Next(rangeMaximumNumbers);

            Damage *= multiplication;
        }
    }


    class MMAFighter : Fighter
    {
        public MMAFighter(string name, int health, int damage) : base(name, health, damage) { }

        protected override void UsePower()
        {
            Random random = new Random();
            int rangeMaximumNumbers = 3;
            int chance = random.Next(rangeMaximumNumbers);

            switch (chance)
            {
                case 0:
                    KickTyoeOne();
                    break;
                case 1:
                    KickTyoeTwo();
                    break;
                case 2:
                    KickTyoeFree();
                    break;
            }
        }

        private void KickTyoeOne()
        {
            Random random = new Random();
            int maximumMultiplication = 3;
            int multiplication = random.Next(maximumMultiplication);

            Damage *= multiplication;
        }

        private void KickTyoeTwo()
        {
            int damageBoost = 20;
            Damage += damageBoost;
        }

        private void KickTyoeFree()
        {
            int damageBoost = 5;
            int multiplication = 2;
            Damage += damageBoost;
            Damage *= multiplication;
        }
    }
}
