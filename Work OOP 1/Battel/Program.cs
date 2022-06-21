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

        protected Random random = new Random();

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
            int rangeMaximumNumbers = 100;
            int chance = random.Next(rangeMaximumNumbers);
            int chanceUsePower = 60;

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
            _fighters.Add(new Boxer("Boxer chempion", 400, 30));
            _fighters.Add(new Jiudgidcu("Jiudgidcu master", 350, 40));
            _fighters.Add(new KarateBoy("Karate Boy", 300, 25));
            _fighters.Add(new Aicido("Aicido Man", 250, 35));
            _fighters.Add(new MMA("Fighter MMA", 150, 50));
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
                Console.WriteLine("Socefull ");
            }
        }

        private void Show()
        {
            Console.WriteLine("list fighters ");

            for (int i = 0; i < _fighters.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + " Name: " + _fighters[i].Name +
                   " Health: " + _fighters[i].Health + " Damage: " + _fighters[i].Damage);              
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
            int rangeMaximumNumbers = 2;
            int chance = random.Next(rangeMaximumNumbers);

            if (chance == 1)
            {
                Console.WriteLine("Huck ");
                Damage += _damageBoostTypeOne;
            }
            else
            {
                Console.WriteLine("Right ");
                Damage += _damageBoostTypeTwo;
            }
        }
    }

    class KarateBoy : Fighter
    {     
        private int _rangeMaximumNumbers = 6;

        public KarateBoy(string name, int health, int damage) : base(name, health, damage) { }

        protected override void UsePower()
        {          
            int multiplication = random.Next(_rangeMaximumNumbers);

            Console.WriteLine("A series of blows ");
            Damage *= multiplication;
        }
    }


    class MMA : Fighter
    {
        private int _rangeMaximumNumbers = 3;
        private int _maximumMultiplication = 3;
        private int _damageBoost = 20;
        private int _multiplication = 2;

        public MMA(string name, int health, int damage) : base(name, health, damage) { }

        protected override void UsePower()
        {
            int chance = random.Next(_rangeMaximumNumbers);

            switch (chance)
            {
                case 0:
                    KickTypeOne();
                    break;
                case 1:
                    KickTypeTwo();
                    break;
                case 2:
                    KickTypeFree();
                    break;
            }
        }

        private void KickTypeOne()
        {            
            int multiplication = random.Next(_maximumMultiplication);
            Console.WriteLine("Boost multiplication ");

            Damage *= multiplication;
        }

        private void KickTypeTwo()
        {
            Console.WriteLine("Boost damage ");
            Damage += _damageBoost;
        }

        private void KickTypeFree()
        {
            _damageBoost = 5;

            Console.WriteLine("Boost damage and multiplication damage ");
            Damage += _damageBoost;
            Damage *= _multiplication;
        }
    }

    class Jiudgidcu : Fighter
    {
        private int _maximumBoost = 70;

        public Jiudgidcu(string name, int health, int damage) : base(name, health, damage) { }

        protected override void UsePower()
        {
            Console.WriteLine("Boost damage random power ");
            Damage += random.Next(_maximumBoost);
        }
    }

    class Aicido : Fighter
    {
        private int _boostHelth = 30;
        public Aicido(string name, int health, int damage) : base(name, health, damage) { }

        protected override void UsePower()
        {
            Console.WriteLine("Boost health ");
            Health += _boostHelth;
        }
    }
}
