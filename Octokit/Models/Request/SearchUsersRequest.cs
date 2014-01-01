﻿using Octokit.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octokit
{
    /// <summary>
    /// Searching Users
    /// </summary>
    public class SearchUsersRequest
    {
        public SearchUsersRequest(string term)
        {
            Ensure.ArgumentNotNullOrEmptyString(term, "term");
            Term = term;
            Page = 1;
            PerPage = 100;
            Order = SortDirection.Descending;
        }

        /// <summary>
        /// The search terms. This can be any combination of the supported user search parameters:
        /// <remarks>http://developer.github.com/v3/search/#search-users</remarks>
        /// </summary>
        public string Term { get; private set; }

        /// <summary>
        /// For http://developer.github.com/v3/search/#search-users
        /// Optional Sort field. One of followers, repositories, or joined. If not provided (null), results are sorted by best match.
        /// </summary>
        public SortUsers? Sort { get; set; }

        /// <summary>
        /// Optional Sort order if sort parameter is provided. One of asc or desc; the default is desc.
        /// </summary>
        public SortDirection Order { get; set; }

        /// <summary>
        /// Page of paginated results
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Number of items per page
        /// </summary>
        public int PerPage { get; set; }

        /// <summary>
        /// Filter users based on the number of followers they have.
        /// </summary>
        public Range Followers { get; set; }

        /// <summary>
        /// Filter users based on when they joined.
        /// </summary>
        public DateRange Created { get; set; }

        /// <summary>
        /// Filter users by the location indicated in their profile.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Filters users based on the number of repositories they have.
        /// </summary>
        public Range Repositories { get; set; }

        /// <summary>
        /// Search for users that have repositories that match a certain language.
        /// </summary>
        public Language Language { get; set; }

        /// <summary>
        /// With this qualifier you can restrict the search to just personal accounts or just organization accounts.
        /// </summary>
        public AccountType Type { get; set; }

        private IEnumerable<UserInQualifier> _inQualifier;

        /// <summary>
        /// Qualifies which fields are searched. With this qualifier you can restrict the search to just the username, public email, full name, or any combination of these.
        /// </summary>
        public IEnumerable<UserInQualifier> In
        {
            get
            {
                return _inQualifier;
            }
            set
            {
                if (value != null && value.Any())
                    _inQualifier = value.Distinct().ToList();
            }
        }
    }

    public enum AccountType
    {
        User,
        Org
    }

    public enum UserInQualifier
    {
        Username,
        Email,
        FullName
    }

    public enum SortUsers
    {
        Followers,
        Repositories,
        Joined
    }
}
