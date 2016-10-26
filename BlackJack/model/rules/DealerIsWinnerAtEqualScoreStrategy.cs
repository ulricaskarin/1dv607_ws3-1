using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class DealerIsWinnerAtEqualScoreStrategy : IWinnerRule
    {
        public bool IsDealerWinner(Player a_player, Dealer a_dealer)
        {
            if (a_player.CalcScore() > 21)
            {
                return true;
            }
            if (a_dealer.CalcScore() > 21)
            {
                return false;
            }
            return a_dealer.CalcScore() >= a_player.CalcScore();
        }
    }
}
