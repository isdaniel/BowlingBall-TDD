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
                List<int> _tempPins = new List<int>();

                int result = 0;

                for (int i = 0; i < _pinsStore.Count; i++)
                {
                    _tempPins.Add(_pinsStore[i]);

                    if (_pinsStore[i] == 10)
                    {
                        _tempPins.Add(0);
                    }
                }

                for (int i = 0; i < _tempPins.Count; i++)
                {
                    if (_tempPins[i] == 10 && i - 2 >= 0)
                    {
                        result += _tempPins[i] + 
                                  _tempPins[i - 1] +
                                  _tempPins[i - 2];
                    }
                    else
                        result += _tempPins[i];
                }

                return result; 
            }
        }
    }

    public class CalculationException : Exception
    {
        public CalculationException()
        {

        }

        public CalculationException(string errorMsg) : base(errorMsg)
        {

        }
    }
}