using System;
using System.Collections.Generic;

namespace OOP_4_Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            Player player = new Player();
            string comand;
            bool isWork = true;

            while(isWork)
            {
                Console.WriteLine("Enter comand: \n1.Put one\n2.Put moore\n3.Result\n4.Esc");
                Console.Write("Enter comand: ");
                comand = Console.ReadLine();

                switch(comand)
                {
                    case "1":
                        player.GetCard(deck);
                        break;
                    case "2":
                        PutMooreCards(player, deck);
                        break;
                    case "3":
                        player.ShowCards();
                        break;
                    case "4":
                        isWork = false;
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }

            static void PutMooreCards(Player player, Deck deck)
            {
                int userNumbersCards;
                string massege = Console.ReadLine();
                bool isStringNumber;

                Console.Write("Enter nubers cards for you: ");

                isStringNumber = int.TryParse(massege, out userNumbersCards);
                if (isStringNumber)
                {
                    for (int i = 0; i < userNumbersCards; i++)
                        player.GetCard(deck);
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
        }
    }

    class Card
    { 
        public string Name { get; private set; }
        public int Weight { get; private set; }

        public Card(string name, int weight)
        {
            Name = name;
            Weight = weight;
        }
    }

    class Deck
    {
        private List<Card> _cards = new List<Card>()
        {
            new Card("A", 1),new Card("B", 2), new Card("C", 3), 
            new Card("D", 4), new Card("I", 5), new Card("F", 6)
        };
        private Random _random = new Random();

        public Deck(){}

        public bool TryGetCard(out Card card)
        {
            if (_cards.Count > 0)
            {
                card = _cards[GetNumberCard()];
                _cards.Remove(card);
                return true;
            }
            else
            {
                card = null;
                return false;
            }
        }

        private int GetNumberCard()
        {
            int numberCard = 0;
            int minimalNumberCard = 0;
            int maximumNumberCard = 6;

            if (_cards.Count > maximumNumberCard)
            {
                numberCard = _random.Next(minimalNumberCard, maximumNumberCard);
                maximumNumberCard--;
            }

            return numberCard;
        }
    }

    class Player
    {
        private List<Card> _onHand = new List<Card>();

        public void GetCard(Deck deck)
        {
            if(deck.TryGetCard(out Card card))
            {
                _onHand.Add(card);
                ShowCards();
            }
        }

        public void ShowCards()
        {
            for(int i = 0; i < _onHand.Count; i++)
            {
                Console.WriteLine($"Card: {_onHand[i].Name} Wight: {_onHand[i].Weight}");
            }
        }
    }
}
