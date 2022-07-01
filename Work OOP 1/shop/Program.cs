//using System;
//using System.Collections.Generic;

//namespace shop
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Seller seller1 = new Seller();

//            seller1.ShowProducts();
//        }
//    }

//    class Seller
//    {
//        private List<Product> _products = new List<Product>()
//        {
//            new Product("Apple", 1), new Product("Sword", 100), new Product("Mace", 150)
//        };


//        public Seller() {}

//        public void ShowProducts()
//        {
//            for (int i = 0; _products.Count > i; i++)
//            {
//                Console.WriteLine(_products[i].Name + " " + _products[i].Price);
//            }
//        }

//    //    public bool TryGetProduct(string nameOfProduct, out Product product)
//    //    {
//    //        if(_products.Count > 0)
//    //        {
//    //            for (int i = 0; i < _products.Count; i++)
//    //            {
//    //                if (nameOfProduct == _products[i].Name)
//    //                {
//    //                    _products.Remove(_products[i]);
//    //                    return true;
//    //                }
//    //            }
//    //        }
//    //        else
//    //        {
//    //            product = null;
//    //            return false;
//    //        }
//    //    }
//    //}

//    class Player
//    {
//        private List<Product> _bag = new List<Product>();

//        public int numberOfProductForReqwest;

//        public int Money { get; private set; }

//        Player(int money)
//        {
//            Money = money;
//        }

//        //public void GetProduckt(Seller seller)
//        //{
//        //    if (seller.TryGetProduct(numberOfProductForReqwest, out Product product))
//        //    {
//        //        _bag.Add(product);              
//        //    }
//        //}
//    }

//    class Product
//    {
//        public string Name { get; private set; }
//        public int Price { get; private set; }

//        public Product(string name, int price)
//        {
//            Name = name;
//            Price = price;
//        }
//    }
//}