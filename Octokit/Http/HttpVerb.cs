using DotNetHttp35;

namespace Octokit.Internal
{
    internal static class HttpVerb
    {
        static readonly HttpMethod patch = new HttpMethod("PATCH");

        internal static HttpMethod Patch
        {
            get { return patch; }
        }
    }
}
