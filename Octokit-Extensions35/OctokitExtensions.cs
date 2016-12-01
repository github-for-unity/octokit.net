using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Octokit_Extensions35
{
    public interface IAwaiter
    {

    }

    public static class OctokitExtensions
    {
        public static IAwaiter GetAwaiter(this object obj)
        {
            return null;
        }
    }
}
