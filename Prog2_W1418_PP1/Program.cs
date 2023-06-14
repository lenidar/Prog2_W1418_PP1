using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Prog2_W1418_PP1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int[]> cards = new List<int[]>();
            List<int[]> hand = new List<int[]>();
            string[] suits = { "Hearts", "Spades","Diamonds","Clubs"};
            string[] values = { "Ace", "Two", "Three","Four","Five","Six","Seven","Eight","Nine","Ten","Jack","Queen","King"};

            for(int x = 0; x < suits.Length; x++)
            {
                for(int y = 0; y < values.Length; y++)
                {
                    cards.Add(new int[] { x, y });
                }
            }    

            cards = shuffleCards(cards, 0);

            // draw 7 cards
            while (hand.Count < 7)
            {
                hand.Add(drawCard(cards));
                cards = removeTopCardFromDeck(cards);
            }

            // display hand
            displayHand(hand);
            Console.ReadKey();
        }

        static List<int[]> shuffleCards(List<int[]> cards, int count)
        {
            // a deck, to be considered shuffled, has to be shuffled at least 7 times
            Random rnd = new Random();
            List<int[]> tempCards = new List<int[]>();
            int temp = 0;

            while(cards.Count > 0)
            {
                temp = rnd.Next(0, cards.Count);
                tempCards.Add(cards[temp]);
                cards.RemoveAt(temp);
            }

            cards = new List<int[]>(tempCards);

            if (count < 7)
            {
                count = count + 1;
                cards = shuffleCards(cards, count);
            }

            return cards;
        }

        static int[] drawCard(List<int[]> cards)
        {
            return cards[0];
        }

        static List<int[]> removeTopCardFromDeck(List<int[]> cards)
        {
            cards.RemoveAt(0);
            return cards;
        }

        static void displayHand(List<int[]> hand)
        {
            string[] suits = { "Hearts", "Spades", "Diamonds", "Clubs" };
            string[] values = { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };

            Console.WriteLine("Your hand consists of:");
            foreach (int[] card in hand)
                Console.WriteLine("{1} of {0}", suits[card[0]], values[card[1]]);
        }
    }
}
