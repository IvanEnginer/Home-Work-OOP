using System;
using System.Collections.Generic;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            Station station = new Station();
            
            bool isWork = true;
            bool trainIsFill = true;
            string comand;

            while (isWork)
            {
                station.ShowInfoTrain();
                station.CreatDirection();
                station.SellTickets();
                Console.Clear();
                station.ShowInfo();

                while (trainIsFill)
                {
                    Console.Clear();
                    station.ShowInfo();
                    trainIsFill = station.TryFillTrain();
                }

                Console.Clear();
                station.ShowInfo();
                station.ShowInfoTrain();
                Console.WriteLine("Press key for departure train or enter no");

                comand = Console.ReadLine();
                Console.Clear();

                if (comand == "no")
                {
                    isWork = false;
                }

                station.DepartudTrain();
                trainIsFill = true;
            }
        }
    }

    class Station
    {
        private int _minimumSelltikets = 10;
        private int _maxiumSellTickets = 250;
        private Queue<Direction> _directions = new Queue<Direction>();
        private Random _random = new Random();
        private Train _train = new Train();

        public int Tikets { get; private set; }
        public Station()
        {
        }

        public void DepartudTrain()
        {
            _directions.Dequeue();
            _train.Departude();
        }

        public void CreatDirection()
        {
            string pointDeparture;
            string pointArivale;

            Console.WriteLine("Enter point departure: ");
            pointDeparture = Console.ReadLine();
            Console.WriteLine("Enter point arivale: ");
            pointArivale = Console.ReadLine();

            _directions.Enqueue(new Direction(pointDeparture, pointArivale, StatusDeparture.NoDeparture));
        }

        public void ShowInfo()
        {
            foreach (Direction direction in _directions)
            {
                Console.Write($"Departure: {direction.PointDeparture}. Arivale: {direction.PointArivale}. Status {direction.Status} ");
            }
            Console.WriteLine($"Tickets sold {Tikets}. Capasity train {_train.GetCapasityTrain()}");
        }

        public void SellTickets()
        {
            Tikets = _random.Next(_minimumSelltikets, _maxiumSellTickets);
        }

        public bool TryFillTrain()
        {
            bool isNumber;
            string command = "";
            int number;

            Console.WriteLine("Enter class service wagon:\n1.Class A\n2.Class B\n3.Class C");

            command = Console.ReadLine();
            isNumber = int.TryParse(command, out number);

            if (isNumber)
            {
                switch (number)
                {
                    case 1:
                        _train.AddWagon(ClassService.ClassA);
                        break;
                    case 2:
                        _train.AddWagon(ClassService.ClassB);
                        break;
                    case 3:
                        _train.AddWagon(ClassService.ClassC);
                        break;
                }
            }

            if (Tikets >= _train.GetCapasityTrain())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ShowInfoTrain()
        {
            _train.ShowInfo();
        }
    }

    class Direction
    {
        public string PointDeparture { get; private set; }
        public string PointArivale { get; private set; }
        public StatusDeparture Status { get; private set; }

        public Direction(string pointDeparture, string pointArivale, StatusDeparture status)
        {
            PointDeparture = pointDeparture;
            PointArivale = pointArivale;
            Status = status;
        }
    }

    class Train
    {
        private List<Wagon> _wagons = new List<Wagon>();
        private Wagon WagonA = new Wagon(25, "Class A");
        private Wagon WagonB = new Wagon(50, "Class B");
        private Wagon WagonC = new Wagon(75, "Class C");

        public Train() { }

        public void Departude()
        {
            _wagons.Clear();
        }

        public void AddWagon(ClassService classService)
        { 
            switch(classService)
            {
                case ClassService.ClassA:
                    _wagons.Add(WagonA);
                    break;
                case ClassService.ClassB:
                    _wagons.Add(WagonB);
                    break;
                case ClassService.ClassC:
                    _wagons.Add(WagonC);
                    break;
            }
        }

        public void ShowInfo()
        {
            for (int i = 0; i < _wagons.Count; i++)
            {
                Console.WriteLine($"Wagon №{i + 1}. Service {_wagons[i].ClassServices}. Capasity {_wagons[i].Capacity}.");
            }
        }

        public int GetCapasityTrain()
        {
            int reselt = 0;

            for (int i = 0; i < _wagons.Count; i++)
            {
                reselt += _wagons[i].Capacity;
            }

            return reselt;
        }
    }

    class Wagon
    {
        public int Capacity { get; private set; }
        public string ClassServices { get; private set; }

        public Wagon(int capacity, string classServices)
        {
            Capacity = capacity;
            ClassServices = classServices;
        }
    }

    enum ClassService
    { 
        ClassA,
        ClassB,
        ClassC
    }

    enum StatusDeparture
    {
        Departure,
        NoDeparture
    }
}
