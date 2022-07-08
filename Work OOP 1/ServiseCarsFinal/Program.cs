using System;
using System.Collections.Generic;

namespace ServiseCarsFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            Servise servise = new Servise(100, 10);

            while (servise.IsServ());
        }
    }

    class Servise
    {
        public int Cash { get; private set; }
        public int Pay { get; private set; }

        private int queueLenght = 10;

        private Queue<Car> cars = new Queue<Car>();
        private Storeg storeg = new Storeg();

        public Servise(int cash, int pay)
        {
            Cash = cash;
            Pay = pay;

            AddCareToQueue();
        }

        public bool IsServ()
        {
            int fine;

            if (cars.Count > 0)
            {
                detailName nameDetail = cars.Peek().GetBreakDetail();

                if (storeg.StoregIsFill(nameDetail))
                {
                    InstaleDetail();
                    DequeCar();
                    Cash += Pay;
                    Console.WriteLine("Машина обслужина");
                    Console.WriteLine("Цена детали: " + storeg.GetCoastDetail(nameDetail) + " Цена работы: " + Pay + " Баланс сервиса: " + Cash);
                    return true;
                }
                else
                {
                    fine = storeg.GetCoastDetail(nameDetail);
                    Cash -= fine;
                    Console.WriteLine("Не удалось ослужить, штраф fine");
                    return false;
                }
            }

            Console.WriteLine("Автомобилий больше нет");
            return false;
        }

        public void ShowInfoStorege()
        {
            storeg.ShowInfo();
        }

        public void InstaleDetail()
        {
            detailName detail = cars.Peek().GetBreakDetail();
            cars.Peek().EjectBreakDetail(detail);
            storeg.TakeDetale(detail);
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
            Console.WriteLine("В машине неисправна: " + cars.Peek().GetBreakDetail());
        }

        private void AddCareToQueue()
        {
            for (int i = 0; i < queueLenght; i++)
                cars.Enqueue(new Car());
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

        public int GetCoastDetail(detailName name)
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

        public bool StoregIsFill(detailName name)
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

        public void TakeDetale(detailName name)
        {
            for (int i = 0; i < _detales.Count; i++)
            {
                if (_detales[i].Detail.Name == name)
                {
                    _detale detaleSwap = new _detale();
                    detaleSwap.Quntity = _detales[i].Quntity;
                    detaleSwap.Quntity--;
                    detaleSwap.Detail = _detales[i].Detail;
                    _detales[i] = detaleSwap;
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
            _details.Add(new Detail(name));
        }

        public detailName GetBreakDetail()
        {
            for (int i = 0; i < _details.Count; i++)
            {
                if (_details[i].IsBreak)
                {
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
