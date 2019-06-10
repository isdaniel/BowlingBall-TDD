using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingBall
{
    public class BowlingGame
    {
        private List<int> _pinsStore = new List<int>(); 

        public void Roll(int pins)
        {
            _pinsStore.Add(pins);
        }

        public int Score
        {
            get
            {
                int result = 0;
                for (int frame = 0; frame < _pinsStore.Count; frame++)
                {
                    if (IsStrike(frame))
                    {
                        result += 10 + StrikeBonus(frame);
                    }
                    else if (IsSpare(frame))
                    {
                        result += 10 + SpareBonus(frame);
                        frame++;
                    }
                    else if (IsNormal(frame))
                        result += NormalScore(frame);
                }

                return result; 
            }
        }

        private bool IsNormal(int frame)
        {
            return _pinsStore[frame] < 10;
        }

        private bool IsStrike(int frame)
        {
            return _pinsStore[frame] == 10 && 
                   frame + 2 < _pinsStore.Count;
        }

        private bool IsSpare(int frame)
        {
            return frame + 2 < _pinsStore.Count &&
                   _pinsStore[frame] +
                   _pinsStore[frame + 1] == 10;
        }

        private int SpareBonus(int frame)
        {
            return _pinsStore[frame + 2];
        }

        private int NormalScore(int frame)
        {
            return _pinsStore[frame];
        }

        private int StrikeBonus(int frame)
        {
            return  _pinsStore[frame + 1] + _pinsStore[frame + 2];
        }
    }
}