using System;
using System.Collections.Generic;

namespace Car_service
{
    class Program
    {
        static void Main(string[] args)
        {
            Servise servise = new Servise(100, 10);

            bool isWork = true;

            while (isWork)
            {
                Console.Write("1. К машине \n2. На склад\n3. Выход\nВведите команду: ");

                if (GetNumber(out int number))
                {
                    switch (number)
                    {
                        case 1:
                            HendelCar(servise);
                            break;
                        case 2:
                            HendelStorege(servise);
                            
                            break;
                        case 3:
                            isWork = false;
                            break;
                    }
                }

                Console.ReadKey();
            }
        }

        static void HendelCar(Servise servise)
        {
            Console.Clear();
            Console.Write("1. Осмотреть машину \n2. Заменить деталь\nВведите команду: ");

            if (GetNumber(out int number))
            {
                switch (number)
                {
                    case 1:
                        servise.ShowBreakCarDetail();
                        break;
                    case 2:
                        servise.InstaleDetail();
                        break;
                }
            }

            Console.ReadKey();
            Console.Clear();
        }

        static void HendelStorege(Servise servise)
        {
            Console.Clear();
            Console.Write("На складе\n");
            servise.ShowInfoStorege();
            Console.ReadKey();
        }

        static bool GetNumber(out int number)
        {
            string command;

            command = Console.ReadLine();
            return int.TryParse(command, out number);
        }
    }

    class Servise
    {
        public int Cash { get; private set; }
        public int Pay { get; private set; }

        private int _fine;
        private int queueLenght = 10;

        private List<detailName> detale = new List<detailName>();
        private detailName datale1;

        private Queue<Car> cars = new Queue<Car>();
        private Storeg storeg = new Storeg();

        public Servise(int cash, int pay)
        {
            Cash = cash;
            Pay = pay;

            AddCareToQueue();
        }

        public void InstaleDetail()
        {
            detailName detail = cars.Peek().GetBreakDetail();
            cars.Peek().EjectBreakDetail(detail);
            //cars.Peek().InstaleDetail(detale[0]);
            storeg.EcjectDetale(detail);
            //cars.Peek().InstaleDetail(detail);
            detale.Clear();
        }

        public bool DequeCar()
        {
            if (cars.Peek().GetBreakDetail() == detailName.Nothing)
            {
                cars.Dequeue();
                return true;
            }

            return false;
        }

        public void ShowBreakCarDetail()
        {
            detale.Add(cars.Peek().GetBreakDetail());
            Console.WriteLine("В машине неисправна: " + cars.Peek().GetBreakDetail());
        }

        public bool QueueIsfill()
        {
            if (cars.Count > 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Queue end!");
                return false;
            }
        }

        public void ShowInfoCar()
        {
            Console.WriteLine(cars.Peek().GetBreakDetail());
        }

        public void ShowInfoStorege()
        {
            storeg.ShowInfo();
            Console.ReadKey();
            Console.Clear();
        }

        private void AddCareToQueue()
        {
            for (int i = 0; i < queueLenght; i++)
                cars.Enqueue(new Car());
        }
    }

    class Car
    {
        private detailName _detalName;

        private int _coastDetail;

        private Random _random = new Random();

        private List<Detail> _details = new List<Detail>();

        public Car()
        {
            AddDetail();
            BreakDetail();
        }

        public void ShowInfo()
        {
            foreach (Detail detalie in _details)
            {
                Console.WriteLine(detalie.Name + " " + detalie.Coast + " " + detalie.IsBreak);
            }
        }

        public void EjectBreakDetail(detailName name)
        {
            for (int i = 0; i < _details.Count; i++)
            {
                if (_details[i].Name == name)
                {
                    _details.RemoveAt(i);
                }
            }
        }

        public void InstaleDetail(detailName name)
        {
            _details.Add(new Detail(name, _coastDetail, false));
        }

        public detailName GetBreakDetail()
        {
            for (int i = 0; i < _details.Count; i++)
            {
                if (_details[i].IsBreak)
                {
                    _coastDetail = _details[i].Coast;
                    return _details[i].Name;
                }
            }
            return detailName.Nothing;
        }

        private void AddDetail()
        {
            _details.Add(new Detail(detailName.Glass));
            _details.Add(new Detail(detailName.Door));
            _details.Add(new Detail(detailName.Roof));
            _details.Add(new Detail(detailName.Wheel));
        }

        private void BreakDetail()
        {
            _details[_random.Next(0, _details.Count)].Break();
        }
    }

    class Storeg
    {
        private List<_detale> _detales = new List<_detale>();

        private int _minimumCoast = 10;
        private int _maximumCoast = 100;
        private int _minimumSize = 5;
        private int _maximumSize = 20;

        private Random _random = new Random();

        private struct _detale
        {
            public Detail Detail;
            public int Quntity;

            public _detale(Detail detail, int quntity)
            {
                Detail = detail;
                Quntity = quntity;
            }
        }

        public Storeg()
        {
            Fill();
        }

        public void EcjectDetale(detailName name)
        {
            for (int i = 0; i < _detales.Count; i++)
            {
                if (_detales[i].Detail.Name == name)
                {
                    _detale detale = new _detale();
                    detale.Quntity = _detales[i].Quntity;
                    detale.Quntity--;
                    _detales[i] = detale;
                }
            }
        }

        public void ShowInfo()
        {
            int position = 0;

            foreach (_detale detail in _detales)
            {
                Console.WriteLine(++position + ". " + detail.Detail.Name + ": " + detail.Quntity);
            }
        }

        private int GetCoast()
        {
            return _random.Next(_minimumCoast, _maximumCoast);
        }

        private int GetSize()
        {
            return _random.Next(_minimumSize, _maximumSize);
        }

        private void Fill()
        {
            _detales.Add(new _detale(new Detail(detailName.Glass, GetCoast()), GetSize()));
            _detales.Add(new _detale(new Detail(detailName.Door, GetCoast()), GetSize()));
            _detales.Add(new _detale(new Detail(detailName.Roof, GetCoast()), GetSize()));
            _detales.Add(new _detale(new Detail(detailName.Wheel, GetCoast()), GetSize()));
        }
    }

    class Detail
    {
        public detailName Name { get; private set; }
        public int Coast { get; private set; }
        public bool IsBreak { get; private set; }

        private const int minimumCoast = 10;

        public Detail(detailName name, int coast = minimumCoast, bool status = false)
        {
            Name = name;
            Coast = coast;
            IsBreak = status;
        }

        public void Break()
        {
            IsBreak = true;
        }
    }

    enum detailName
    {
        Glass,
        Door,
        Roof,
        Wheel,
        Nothing
    }
}
