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
            CarService servise = new CarService(100);

            servise.Work();
        }
    }

    class CarService
    {
        private int _queueLenght = 10;
        private int _cash;
        private int _pay = 10;

        private Queue<Car> _cars = new Queue<Car>();
        private Storage _storage = new Storage();

        public CarService(int cash)
        {
            _cash = cash;

            AddCareToQueue();
        }

        public void Work()
        {
            int fine;
            bool isServiced = true;
            bool isCarInQueue = true;

            while (isServiced && isCarInQueue)
            {
                if (_cars.Count > 0)
                {
                    //DetailName nameDetail = _cars.Peek().GetBreakDetail();



                    if (_storage.IsContains())
                    {
                        InstaleDetail(nameDetail);
                        DequeCar();
                        _cash += _pay;
                        Console.WriteLine("Машина обслужина");
                        Console.WriteLine("Цена детали: " + _storage.GetCoastDetail(nameDetail) + " Цена работы: " + _pay + " Баланс сервиса: " + _cash);
                        isServiced = true;
                    }
                    else
                    {
                        fine = _storage.GetCoastDetail(nameDetail);
                        _cash -= fine;
                        Console.WriteLine("Не удалось ослужить, штраф fine");
                        isServiced = false;
                    }
                }
                else
                {
                    Console.WriteLine("Автомобилий больше нет");
                    isCarInQueue = false;
                }
            }
        }

        private void InstaleDetail(Detail detail)
        {
            //DetailName detail = _cars.Peek().GetBreakDetail();
            _cars.Peek().EjectBreakDetail(detail);
            _storage.TakeDetale(detail);

        }

        //private void InstaleDetail(Detail detail)
        //{
        //    //DetailName detail = _cars.Peek().GetBreakDetail();
        //    //_cars.Peek().EjectBreakDetail(detail);
        //    //_storage.TakeDetale(detail);

        //}

        private bool DequeCar()
        {
            if (_cars.Peek().GetBreakDetail() == null)
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

    class Storage
    {
        private List<_detailsBox> _detales = new List<_detailsBox>();

        private int _minimumCost = 10;
        private int _maximumCost = 100;
        private int _minimumSize = 5;
        private int _maximumSize = 20;

        private Random _random = new Random();

        public Storage()
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
                        return _detales[i].Detail.Cost;
                    }
                }
            }
            return 0;
        }

        public bool IsContains(DetailName name)
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

        public void TakeDetale(DetailName detailName)
        {
            for (int i = 0; i < _detales.Count; i++)
            {
                if (_detales[i].Detail.Name == detailName)
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
            return _random.Next(_minimumCost, _maximumCost);
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
                Console.WriteLine(detalie.Name + " " + detalie.Cost + " " + detalie.IsBreak);
            }
        }

        //public void EjectBreakDetail(DetailName name)
        //{
        //    for (int i = 0; i < _details.Count; i++)
        //    {
        //        if (_details[i].Name == name)
        //        {
        //            _details.RemoveAt(i);
        //        }
        //    }
        //}

        public void EjectBreakDetail(Detail detail)
        {
            for (int i = 0; i < _details.Count; i++)
            {
                if (_details[i].Name == detail.Name)
                {
                    _details.RemoveAt(i);
                }
            }
        }

        public void InstaleDetail(DetailName name)
        {
            _details.Add(new Detail(name));
        }

        public Detail GetBreakDetail()
        {
            for (int i = 0; i < _details.Count; i++)
            {
                if (_details[i].IsBreak)
                {
                    return _details[i];
                }
            }
            return null;
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
        public int Cost { get; private set; }
        public bool IsBreak { get; private set; }

        private const int _minimumCost = 10;

        public Detail(DetailName name, int cost = _minimumCost, bool status = false)
        {
            Name = name;
            Cost = cost;
            IsBreak = status;
        }

        public void Break()
        {
            IsBreak = true;
        }
    }
}