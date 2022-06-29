using System;
using System.Collections.Generic;

namespace Aquarium
{
    class Program
    {
        static void Main(string[] args)
        {
            Aquarium aquarium = new Aquarium();
            bool isWork = true;

            while (isWork)
            {
                aquarium.ShowAquarium();
                Console.WriteLine("\nAquarium" +
                    "\n1. Add fish" +
                    "\n2. Ejkect fish" +
                    "\n3. Esc.");
                Console.Write("Enter command: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        aquarium.AddFish();
                        break;
                    case "2":
                        aquarium.RemoveFish();
                        break;
                    case "3":
                        Console.WriteLine("Esc");
                        isWork = false;
                        break;
                    default:
                        Console.WriteLine("Comand encorect");
                        break;
                }

                aquarium.UpdateAgeFish();
                aquarium.RemoveDeadFish();
                Console.Clear();
            }
        }
    }

    class Aquarium
    {
        private int _size = 4;
        private List<Fish> _fishes = new List<Fish>();

        public Aquarium() { }

        public void AddFish()
        {
            string name;
            int age;

            if (_size <= _fishes.Count)
            {
                Console.Clear();
                Console.WriteLine("Aquarium is feal");
                Console.ReadKey();
            }
            else
            {
                Console.Write("Enter fish name: ");
                name = Console.ReadLine();
                Console.Write("Enter fish age: ");
                age = GetInputAge();

                if (age == 0)
                {
                    Console.WriteLine("Error");
                }
                else
                {
                    _fishes.Add(new Fish(name, age));
                }
            }
        }

        public void ShowAquarium()
        {
            int numberFish = 1;
            Console.WriteLine($"\nFish in aquarium - {_fishes.Count}");

            foreach (Fish fish in _fishes)
            {
                Console.WriteLine($"{numberFish++}. {fish.Name}, age {fish.Age}");
            }
        }

        public void RemoveFish()
        {
            if (TryGetFish(out Fish fish))
            {
                _fishes.Remove(fish);
            }
        }

        public void UpdateAgeFish()
        {
            foreach (Fish fish in _fishes)
            {
                fish.Live();
            }
        }

        public void RemoveDeadFish()
        {
            for (int i = 0; i < _fishes.Count; i++)
            {
                if (_fishes[i].IsAlive == false)
                {
                    _fishes.Remove(_fishes[i]);
                }
            }
        }

        private bool TryGetFish(out Fish fish)
        {
            Console.Write("Enter number fish:");
            bool isNumber = int.TryParse(Console.ReadLine(), out int inputNumberFish);

            if (isNumber == false)
            {
                Console.WriteLine("Error");
                fish = null;
                return false;
            }
            else if (inputNumberFish > 0 && inputNumberFish - 1 < _fishes.Count)
            {
                fish = _fishes[inputNumberFish - 1];
                Console.WriteLine("Fish ejeckt");
                return true;
            }
            else
            {
                Console.WriteLine("Fish not existe");
                fish = null;
                return false;
            }
        }

        private int GetInputAge()
        {
            bool isNumber = int.TryParse(Console.ReadLine(), out int age);

            if (isNumber)
            {
                return age;
            }
            else
            {
                Console.WriteLine("Error");
                return 0;
            }
        }
    }

    class Fish
    {
        private Random _random = new Random();
        private int _minimumDeadAge = 2;
        private int _maximumDeadAge = 10;
        private int _deadAge;

        public int Age { get; private set; }
        public string Name { get; private set; }

        public bool IsAlive { get { return Age < _deadAge; } private set { } }

        public Fish(string name, int age)
        {
            Age = age;
            Name = name;
            _deadAge = _random.Next(_minimumDeadAge, _maximumDeadAge);
        }

        public void Live()
        {
            Age++;
        }
    }
}
