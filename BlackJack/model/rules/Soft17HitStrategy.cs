using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class Soft17HitStrategy : IHitStrategy
    {
        private const int HitLimit = 17;
        private Player _dealer;
        public bool DoHit(model.Player aDealer)
        {
            _dealer = aDealer;
            var score = _dealer.CalcScore();
            return score < HitLimit || IsSoft17(score);
        }

        private bool IsSoft17(int score)
        {
            return score == 17 && HasAceCountedAsOne(score);
        }

        private bool HasAceCountedAsOne(int score)
        {
            return _dealer.CalcScore() != CalcHighScore();
        }

        private int CalcHighScore()
        {
            int[] cardScores = new int[(int)model.Card.Value.Count]
{2, 3, 4, 5, 6, 7, 8, 9, 10, 10 ,10 ,10, 11};
            int score = 0;

            foreach (Card c in _dealer.GetHand())
            {
                if (c.GetValue() != Card.Value.Hidden)
                {
                    score += cardScores[(int)c.GetValue()];
                }
            }
            return score;
        }
    }
}
