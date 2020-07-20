using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessTracker.Common.Infrastructure
{
    public static class ActionExtensions
    {
        public static Action OnExceptionContinue(this Action action)
        {
            return () =>
            {
                try
                {
                    action();
                }
                catch
                {
                }
            };
        }
    }
}
