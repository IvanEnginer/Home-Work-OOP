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
                Console.WriteLine("6. Esc");
                Console.Write("\nEnter command: ");

                if (int.TryParse(Console.ReadLine(), out command))
                {
                    switch (command)
                    {
                        case 1:
                            ShowInfoAviary(zoo1, "Cow");
                            break;
                        case 2:
                            ShowInfoAviary(zoo1, "Dog");
                            break;
                        case 3:
                            ShowInfoAviary(zoo1, "Hours");
                            break;
                        case 4:
                            ShowInfoAviary(zoo1, "Fox");
                            break;
                        case 5:
                            ShowInfoAviary(zoo1, "Bird");
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

        static void ShowInfoAviary(Zoo zoo, string type)
        {
            Console.WriteLine("In aviary");
            zoo.ShowInfoAnimalse(type);
        }
    }

    class Zoo
    {
        private List<Aviary> _aviarys = new List<Aviary>();

        public Zoo()
        {
            _aviarys.Add(new Aviary("Cow Wally", "Cow"));
            _aviarys.Add(new Aviary("Dog Home", "Dog"));
            _aviarys.Add(new Aviary("Hours river", "Hours"));
            _aviarys.Add(new Aviary("Fox root", "Fox"));
            _aviarys.Add(new Aviary("Bird song", "Bird"));
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

        public string ShowTypeAviary(string name)
        {
            foreach (Aviary aviary in _aviarys)
            {
                if (name == aviary.Name)
                {
                    return aviary.Type;
                }
                else
                {
                    return "error";
                }
            }
            return "error";
        }

        public void ShowInfoAnimalse(string type)
        {
            switch (type)
            {
                case "Cow":
                    _aviarys[0].ShowInfoAviary();
                    break;
                case "Dog":
                    _aviarys[1].ShowInfoAviary();
                    break;
                case "Hours":
                    _aviarys[2].ShowInfoAviary();
                    break;
                case "Fox":
                    _aviarys[3].ShowInfoAviary();
                    break;
                case "Bird":
                    _aviarys[4].ShowInfoAviary();
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
    }

    class Aviary
    {
        private List<Animal> _animals = new List<Animal>();
        public string Name { get; private set; }
        public string Type { get; private set; }

        public Aviary(string name, string type)
        {
            Name = name;
            Type = type;
            AddAnimal(type);
        }

        public void AddAnimal(string type)
        {
            if (type == "Cow")
            {
                _animals.Add(new Cow("Cow one", Gender.Male));
                _animals.Add(new Cow("Cow two", Gender.Male));
                _animals.Add(new Cow("Cow free", Gender.Female));
            }
            else if (type == "Dog")
            {
                _animals.Add(new Dog("Dog one", Gender.Male));
                _animals.Add(new Dog("Dog two", Gender.Male));
            }
            else if (type == "Hours")
            {
                _animals.Add(new Hours("Hours one", Gender.Male));
            }
            else if (type == "Fox")
            {
                _animals.Add(new Fox("Fox one", Gender.Male));
                _animals.Add(new Fox("Fox two", Gender.Male));
                _animals.Add(new Fox("Fox free", Gender.Female));
            }
            else if (type == "Bird")
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