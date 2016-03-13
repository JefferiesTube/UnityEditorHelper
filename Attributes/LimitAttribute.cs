using System;
using UnityEngine;

namespace UnityEditorHelper
{
    public class LimitAttribute : PropertyAttribute
    {
        public enum Mode { LimitLower, LimitUpper, LimitBoth }

        public Mode LimitMode;

        public int LowerLimit;
        public int UpperLimit;

        public LimitAttribute(int lowerLimit) : this(Mode.LimitLower, lowerLimit, int.MaxValue) { }

        public LimitAttribute(int lowerLimit, int upperLimit) : this(Mode.LimitLower, lowerLimit, upperLimit) { }

        public LimitAttribute(Mode mode, int lowerLimit, int upperLimit)
        {
            LimitMode = mode;
            LowerLimit = lowerLimit;
            UpperLimit = upperLimit;
        }

        public int Limit(int value)
        {
            switch (LimitMode)
            {
                case Mode.LimitLower:
                    return Mathf.Clamp(value, LowerLimit, int.MaxValue);
                case Mode.LimitUpper:
                    return Mathf.Clamp(value, int.MinValue, UpperLimit);
                case Mode.LimitBoth:
                    return Mathf.Clamp(value, LowerLimit, UpperLimit);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}