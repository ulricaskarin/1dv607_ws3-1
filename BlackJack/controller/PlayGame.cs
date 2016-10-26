using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.controller
{
    class PlayGame
    {
        public bool Play(model.Game a_game, view.IView a_view)
        {
            a_view.DisplayWelcomeMessage();
            
            a_view.DisplayDealerHand(a_game.GetDealerHand(), a_game.GetDealerScore());
            a_view.DisplayPlayerHand(a_game.GetPlayerHand(), a_game.GetPlayerScore());

            if (a_game.IsGameOver())
            {
                a_view.DisplayGameOver(a_game.IsDealerWinner());
            }
  
            view.GameAction gameAction = a_view.GetAction();

            switch (gameAction) 
            {
                case view.GameAction.Play:
                    a_game.NewGame();
                    return true;

                case view.GameAction.Hit:
                    a_game.Hit();
                    return true;

                case view.GameAction.Stand:
                    a_game.Stand();
                    return true;

                case view.GameAction.Quit:
                    return false;

                case view.GameAction.Invalid:
                    return true;

                default:
                    throw new Exception("GameAction can not be handled.");
            }
        }
    }
}
