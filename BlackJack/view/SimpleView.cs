using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.view
{
    class SimpleView : IView
    {

        public void DisplayWelcomeMessage()
        {
            System.Console.Clear();
            System.Console.WriteLine("Hello Black Jack World");
            System.Console.WriteLine("Type 'p' to Play, 'h' to Hit, 's' to Stand or 'q' to Quit\n");
        }

        private char GetInput()
        {
            return System.Console.ReadKey().KeyChar;
        }

        public GameAction GetAction()
        {
            char input = GetInput();

            switch (input)
            {
                case 'p':
                    return GameAction.Play;

                case 'h':
                    return GameAction.Hit;

                case 's':
                    return GameAction.Stand;

                case 'q':
                    return GameAction.Quit;

                default:
                    return GameAction.Invalid;
            }
        }

        public void Pause()
        {
            System.Threading.Thread.Sleep(1000);
            System.Console.Clear();
            DisplayWelcomeMessage();
        }

        public void DisplayCard(model.Card a_card)
        {
            System.Console.WriteLine("{0} of {1}", a_card.GetValue(), a_card.GetColor());
        }

        public void DisplayPlayerHand(IEnumerable<model.Card> a_hand, int a_score)
        {
            DisplayHand("Player", a_hand, a_score);
        }

        public void DisplayDealerHand(IEnumerable<model.Card> a_hand, int a_score)
        {
            DisplayHand("Dealer", a_hand, a_score);
        }

        private void DisplayHand(String a_name, IEnumerable<model.Card> a_hand, int a_score)
        {
            System.Console.WriteLine("{0} Has: ", a_name);
            foreach (model.Card c in a_hand)
            {
                DisplayCard(c);
            }
            System.Console.WriteLine("Score: {0}", a_score);
            System.Console.WriteLine("");
        }

        public void DisplayGameOver(bool a_dealerIsWinner)
        {
            System.Console.Write("GameOver: ");
            if (a_dealerIsWinner)
            {
                System.Console.WriteLine("Dealer Won!");
            }
            else
            {
                System.Console.WriteLine("You Won!");
            }
            
        }
    }
}
