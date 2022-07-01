using System;
using System.Collections.Generic;

namespace Zoo
{
    class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo1 = new Zoo();

            bool isWork = true;
            int command;

            while (isWork)
            {
                Console.WriteLine("Chose number aviary");
                zoo1.ShowAllAviarys();
                Console.WriteLine((zoo1.GetSizeZoo() + 1) + ". Esc");
                Console.Write("\nEnter command: ");

                if (int.TryParse(Console.ReadLine(), out command))
                {
                    if (command == (zoo1.GetSizeZoo() + 1))
                    {
                        isWork = false;
                    }
                    else
                    {
                        ShowInfoAviary(zoo1, command - 1);
                    }
                }

                Console.ReadKey();
                Console.Clear();
            }    
        }

        static void ShowInfoAviary(Zoo zoo, int number)
        {
            Console.WriteLine("In aviary");
            zoo.ShowInfoAnimalse(number);
        }
    }

    class Zoo
    {
        private List<Aviary> _aviarys = new List<Aviary>();

        public Zoo()
        {
            _aviarys.Add(new Aviary("Cow Wally", 0));
            _aviarys.Add(new Aviary("Dog Home", 1));
            _aviarys.Add(new Aviary("Hours river", 2));
            _aviarys.Add(new Aviary("Fox root", 3));
            _aviarys.Add(new Aviary("Bird song", 4));
        }

        public int GetSizeZoo()
        {
            return _aviarys.Count;
        }

        public void ShowAllAviarys()
        {
            int i = 1;

            foreach (Aviary aviary in _aviarys)
            {
                Console.WriteLine(i + ": " + aviary.Name);
                i++;
            }
        }

        public void ShowInfoAnimalse(int number)
        {
            _aviarys[number].ShowInfoAviary();
        }
    }

    class Aviary
    {
        private List<Animal> _animals = new List<Animal>();
        public string Name { get; private set; }
        public int Number { get; private set; }

        public Aviary(string name, int number)
        {
            Name = name;
            Number = number;
            AddAnimal(number);
        }

        public void AddAnimal(int number)
        {
            if (number == 0)
            {
                _animals.Add(new Cow("Cow one", Gender.Male));
                _animals.Add(new Cow("Cow two", Gender.Male));
                _animals.Add(new Cow("Cow free", Gender.Female));
            }
            else if (number == 1)
            {
                _animals.Add(new Dog("Dog one", Gender.Male));
                _animals.Add(new Dog("Dog two", Gender.Male));
            }
            else if (number == 2)
            {
                _animals.Add(new Hours("Hours one", Gender.Male));
            }
            else if (number == 3)
            {
                _animals.Add(new Fox("Fox one", Gender.Male));
                _animals.Add(new Fox("Fox two", Gender.Male));
                _animals.Add(new Fox("Fox free", Gender.Female));
            }
            else if (number == 4)
            {
                _animals.Add(new Bird("Bird two", Gender.Male));
                _animals.Add(new Bird("Bird free", Gender.Female));
            }
        }

        public void ShowInfoAviary()
        {
            foreach (Animal animal in _animals)
            {
                animal.ShowInfo();
            }
        }
    }

    abstract class Animal
    {
        public string Name { get; private set; }
        public Gender Gender { get; private set; }
        public string Sound { get; private set; }

        public Animal(string name, Gender gender)
        {
            Name = name;
            Gender = gender;
            Sound = Sound;
        }

        public void ShowInfo()
        {
            Console.Write($"Name: {Name}. Gender: {Gender}. Soud: {Sound}.");
            Console.WriteLine();
        }

        protected void SetSound(string sound)
        {
            Sound = sound;
        }
    }

    class Cow : Animal
    {
        public Cow(string name, Gender gender) : base(name, gender)
        {
            SetSound("Mooo");
        }
    }

    class Dog : Animal
    {
        public Dog(string name, Gender gender) : base(name, gender)
        {
            SetSound("Gav");
        }
    }

    class Hours : Animal
    {
        public Hours(string name, Gender gender) : base(name, gender)
        {
            SetSound("Igo go");
        }
    }

    class Fox : Animal
    {
        public Fox(string name, Gender gender) : base(name, gender)
        {
            SetSound("Dig ding wpa wpa");
        }
    }

    class Bird : Animal
    {
        public Bird(string name, Gender gender) : base(name, gender)
        {
            SetSound("Twee");
        }
    }

    enum Gender
    {
        Male,
        Female,
        Uncknow
    }
}