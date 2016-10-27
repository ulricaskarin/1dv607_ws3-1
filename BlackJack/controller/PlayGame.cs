using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackJack.model;
using BlackJack.view;

namespace BlackJack.controller
{
    class PlayGame : ICardRecievedObserver
    {
        private model.Game m_game;
        private IView m_view;

        public PlayGame(model.Game g, IView v)
        {
            m_game = g;
            m_view = v;
            m_game.AddSubscriber(this);
        }

        public bool Play()
        {
            m_view.DisplayWelcomeMessage();
            
            m_view.DisplayDealerHand(m_game.GetDealerHand(), m_game.GetDealerScore());
            m_view.DisplayPlayerHand(m_game.GetPlayerHand(), m_game.GetPlayerScore());

            if (m_game.IsGameOver())
            {
                m_view.DisplayGameOver(m_game.IsDealerWinner());
            }
  
            view.GameAction gameAction = m_view.GetAction();

            switch (gameAction) 
            {
                case view.GameAction.Play:
                    m_game.NewGame();
                    return true;

                case view.GameAction.Hit:
                    m_game.Hit();
                    return true;

                case view.GameAction.Stand:
                    m_game.Stand();
                    return true;

                case view.GameAction.Quit:
                    return false;

                case view.GameAction.Invalid:
                    return true;

                default:
                    throw new Exception("GameAction can not be handled.");
            }
        }

        public void CardRecieved()
        {
            m_view.Pause();
        }
    }
}
