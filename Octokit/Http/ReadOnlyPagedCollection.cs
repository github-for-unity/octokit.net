using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Octokit.Internal
{
    public class ReadOnlyPagedCollection<T> : ReadOnlyCollection<T>, IReadOnlyPagedCollection<T>
    {
        readonly ApiInfo _info;
        readonly Func<Uri, Task<IApiResponse<Net40List<T>>>> _nextPageFunc;

        public ReadOnlyPagedCollection(IApiResponse<Net40List<T>> response, Func<Uri, Task<IApiResponse<Net40List<T>>>> nextPageFunc)
            : base(response != null ? response.Body ?? new Net40List<T>() : new Net40List<T>())
        {
            Ensure.ArgumentNotNull(response, "response");
            Ensure.ArgumentNotNull(nextPageFunc, "nextPageFunc");

            _nextPageFunc = nextPageFunc;
            if (response != null)
            {
                _info = response.HttpResponse.ApiInfo;
            }
        }

        public async Task<IReadOnlyPagedCollection<T>> GetNextPage()
        {
            var nextPageUrl = _info.GetNextPageUrl();
            if (nextPageUrl == null) return null;

            var maybeTask = _nextPageFunc(nextPageUrl);

            if (maybeTask == null)
            {
                return null;
            }

            var response = await maybeTask.ConfigureAwait(false);
            return new ReadOnlyPagedCollection<T>(response, _nextPageFunc);
        }
    }
}
