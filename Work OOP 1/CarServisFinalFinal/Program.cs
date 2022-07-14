using System;
using System.Collections.Generic;

namespace ServiseCarsFinal
{
    enum DetailName
    {
        Glass,
        Door,
        Roof,
        Wheel,
        Nothing
    }

    class Program
    {
        static void Main(string[] args)
        {
            Servise servise = new Servise(100);

            servise.Work();
        }
    }

    class Servise
    {
        private int _queueLenght = 10;
        private int _cash;
        private int _pay = 10;

        private Queue<Car> _cars = new Queue<Car>();
        private Storeg _storeg = new Storeg();

        public Servise(int cash)
        {
            _cash = cash;

            AddCareToQueue();
        }

        public void Work()
        {
            bool IsWork = true;

            while (IsWork)
            {
                IsWork = IsOpen();
            }
        }

        private bool IsOpen()
        {
            int fine;
            bool IsServeced = true;
            bool IsCarInQueue = true;

            if (_cars.Count > 0)
            {
                DetailName nameDetail = _cars.Peek().GetBreakDetail();

                if (_storeg.IsFull(nameDetail))
                {
                    InstaleDetail();
                    DequeCar();
                    _cash += _pay;
                    Console.WriteLine("Машина обслужина");
                    Console.WriteLine("Цена детали: " + _storeg.GetCoastDetail(nameDetail) + " Цена работы: " + _pay + " Баланс сервиса: " + _cash);
                    IsServeced = true;
                    return IsServeced && IsCarInQueue;
                }
                else
                {
                    fine = _storeg.GetCoastDetail(nameDetail);
                    _cash -= fine;
                    Console.WriteLine("Не удалось ослужить, штраф fine");
                    IsServeced = false;
                    return IsServeced && IsCarInQueue;
                }
            }

            Console.WriteLine("Автомобилий больше нет");
            IsCarInQueue = false;
            return IsServeced && IsCarInQueue;
        }

        private void InstaleDetail()
        {
            DetailName detail = _cars.Peek().GetBreakDetail();
            _cars.Peek().EjectBreakDetail(detail);
            _storeg.TakeDetale(detail);
        }

        private bool DequeCar()
        {
            if (_cars.Peek().GetBreakDetail() == DetailName.Nothing)
            {
                _cars.Dequeue();
                return true;
            }

            return false;
        }

        private void ShowBreakCarDetail()
        {
            Console.WriteLine("В машине неисправна: " + _cars.Peek().GetBreakDetail());
        }

        private void AddCareToQueue()
        {
            for (int i = 0; i < _queueLenght; i++)
                _cars.Enqueue(new Car());
        }
    }

    class Storeg
    {
        private List<_detailsBox> _detales = new List<_detailsBox>();

        private int _minimumCoast = 10;
        private int _maximumCoast = 100;
        private int _minimumSize = 5;
        private int _maximumSize = 20;

        private Random _random = new Random();

        public Storeg()
        {
            Fill();
        }

        public int GetCoastDetail(DetailName name)
        {
            for (int i = 0; i < _detales.Count; i++)
            {
                if (_detales[i].Detail.Name == name)
                {
                    if (_detales[i].Quntity != 0)
                    {
                        return _detales[i].Detail.Coast;
                    }
                }
            }
            return 0;
        }

        public bool IsFull(DetailName name)
        {
            for (int i = 0; i < _detales.Count; i++)
            {
                if (_detales[i].Detail.Name == name)
                {
                    if (_detales[i].Quntity != 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void TakeDetale(DetailName name)
        {
            for (int i = 0; i < _detales.Count; i++)
            {
                if (_detales[i].Detail.Name == name)
                {
                    _detailsBox detaleSwap = new _detailsBox();
                    detaleSwap.Quntity = _detales[i].Quntity;
                    detaleSwap.Quntity--;
                    detaleSwap.Detail = _detales[i].Detail;
                    _detales[i] = detaleSwap;
                }
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
            _detales.Add(new _detailsBox(new Detail(DetailName.Glass, GetCoast()), GetSize()));
            _detales.Add(new _detailsBox(new Detail(DetailName.Door, GetCoast()), GetSize()));
            _detales.Add(new _detailsBox(new Detail(DetailName.Roof, GetCoast()), GetSize()));
            _detales.Add(new _detailsBox(new Detail(DetailName.Wheel, GetCoast()), GetSize()));
        }

        private struct _detailsBox
        {
            public Detail Detail;
            public int Quntity;

            public _detailsBox(Detail detail, int quntity)
            {
                Detail = detail;
                Quntity = quntity;
            }
        }
    }

    class Car
    {
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

        public void EjectBreakDetail(DetailName name)
        {
            for (int i = 0; i < _details.Count; i++)
            {
                if (_details[i].Name == name)
                {
                    _details.RemoveAt(i);
                }
            }
        }

        public void InstaleDetail(DetailName name)
        {
            _details.Add(new Detail(name));
        }

        public DetailName GetBreakDetail()
        {
            for (int i = 0; i < _details.Count; i++)
            {
                if (_details[i].IsBreak)
                {
                    return _details[i].Name;
                }
            }
            return DetailName.Nothing;
        }

        private void AddDetail()
        {
            _details.Add(new Detail(DetailName.Glass));
            _details.Add(new Detail(DetailName.Door));
            _details.Add(new Detail(DetailName.Roof));
            _details.Add(new Detail(DetailName.Wheel));
        }

        private void BreakDetail()
        {
            _details[_random.Next(0, _details.Count)].Break();
        }
    }

    class Detail
    {
        public DetailName Name { get; private set; }
        public int Coast { get; private set; }
        public bool IsBreak { get; private set; }

        private const int _minimumCoast = 10;

        public Detail(DetailName name, int coast = _minimumCoast, bool status = false)
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
}