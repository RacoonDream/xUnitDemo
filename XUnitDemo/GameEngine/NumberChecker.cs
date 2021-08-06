using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{
   public class NumberChecker
    {
        public bool IsOddNumber(int a)
        {
            if (a == 1)
                return true;
            return !(a / 2 == 0);
        }
    }
}
