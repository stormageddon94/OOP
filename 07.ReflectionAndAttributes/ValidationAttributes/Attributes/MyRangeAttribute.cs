using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute : Attribute, IVallidator
    {
        private int _minValue;
        private int _maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this._minValue = minValue;
            this._maxValue = maxValue;
        }

        public bool IsValid(object obj)
        {
            if ((int)obj > this._minValue && (int)obj < this._maxValue)
            {
                return true;
            }

            return false;
        }
    }
}
