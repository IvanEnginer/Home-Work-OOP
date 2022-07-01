﻿using System;
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
                Console.WriteLine("6. Esc");
                Console.Write("\nEnter command: ");

                if (int.TryParse(Console.ReadLine(), out command))
                {
                    switch (command)
                    {
                        case 1:
                            ShowInfoAviary(zoo1, 0);
                            break;
                        case 2:
                            ShowInfoAviary(zoo1, 1);
                            break;
                        case 3:
                            ShowInfoAviary(zoo1, 2);
                            break;
                        case 4:
                            ShowInfoAviary(zoo1, 3);
                            break;
                        case 5:
                            ShowInfoAviary(zoo1, 4);
                            break;
                        case 6:
                            isWork = false;
                            break;
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
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string Sound { get; set; }

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
    }

    class Cow : Animal
    {
        public Cow(string name, Gender gender) : base(name, gender)
        {
            Sound = "Mooo";
        }
    }

    class Dog : Animal
    {
        public Dog(string name, Gender gender) : base(name, gender)
        {
            Sound = "Gav";
        }
    }

    class Hours : Animal
    {
        public Hours(string name, Gender gender) : base(name, gender)
        {
            Sound = "Igo go";
        }
    }

    class Fox : Animal
    {
        public Fox(string name, Gender gender) : base(name, gender)
        {
            Sound = "Dig ding wpa wpa";
        }
    }

    class Bird : Animal
    {
        public Bird(string name, Gender gender) : base(name, gender)
        {
            Sound = "Twee";
        }
    }

    enum Gender
    {
        Male,
        Female,
        Uncknow
    }
}