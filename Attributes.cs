using System;
using UnityEngine;

namespace UnityEditorHelper
{
    public class LayerAttribute : PropertyAttribute { }

    public class LimitAttribute : PropertyAttribute
    {
        private enum Mode { LimitLower, LimitUpper, LimitBoth }

        private readonly Mode _limitMode;

        private readonly int _lowerLimit;
        private readonly int _upperLimit;

        public LimitAttribute(int lowerLimit) : this(Mode.LimitLower, lowerLimit, int.MaxValue) { }

        public LimitAttribute(int lowerLimit, int upperLimit) : this(Mode.LimitBoth, lowerLimit, upperLimit) { }

        private LimitAttribute(Mode mode, int lowerLimit, int upperLimit)
        {
            _limitMode = mode;
            _lowerLimit = lowerLimit;
            _upperLimit = upperLimit;
        }

        public int Limit(int value)
        {
            switch (_limitMode)
            {
                case Mode.LimitLower:
                    return Mathf.Clamp(value, _lowerLimit, int.MaxValue);
                case Mode.LimitUpper:
                    return Mathf.Clamp(value, int.MinValue, _upperLimit);
                case Mode.LimitBoth:
                    return Mathf.Clamp(value, _lowerLimit, _upperLimit);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public class SortingLayerAttribute : PropertyAttribute { }

    public class TagAttribute : PropertyAttribute { }
}