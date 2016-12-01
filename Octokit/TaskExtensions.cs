using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Threading.Tasks
{
    public static class TaskExtensions
    {
        public static T ConfigureAwait<T>(this Task<T> task, bool returnToOriginalContext)
        {
            return default(T);
        }
    }
}