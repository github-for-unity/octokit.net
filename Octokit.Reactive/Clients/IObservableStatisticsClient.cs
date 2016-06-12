using System;
using System.Collections.Generic;

namespace Octokit.Reactive
{
    /// <summary>
    /// A client for GitHub's Repository Statistics API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developer.github.com/v3/repos/statistics/">Repository Statistics API documentation</a> for more information.
    /// </remarks>
    public interface IObservableStatisticsClient
    {
        /// <summary>
        /// Returns a list of <see cref="Contributor"/> for the given repository
        /// </summary>
        /// <param name="owner">The owner of the repository</param>
        /// <param name="name">The name of the repository</param>
        /// <returns>A list of <see cref="Contributor"/></returns>
        IObservable<IEnumerable<Contributor>> GetContributors(string owner, string name);

        /// <summary>
        /// Returns the last year of commit activity grouped by week.
        /// </summary>
        /// <param name="owner">The owner of the repository</param>
        /// <param name="name">The name of the repository</param>
        /// <returns>The last year of  <see cref="CommitActivity"/></returns>
        IObservable<CommitActivity> GetCommitActivity(string owner, string name);

        /// <summary>
        /// Returns a weekly aggregate of the number of additions and deletions pushed to a repository.
        /// </summary>
        /// <param name="owner">The owner of the repository</param>
        /// <param name="name">The name of the repository</param>
        /// <returns>Returns a weekly aggregate of the number additions and deletion</returns>
        IObservable<CodeFrequency> GetCodeFrequency(string owner, string name);

        /// <summary>
        /// Returns the total commit counts for the owner and total commit counts in total. 
        /// </summary>
        /// <param name="owner">The owner of the repository</param>
        /// <param name="name">The name of the repository</param>
        /// <returns>Returns <see cref="Participation"/>from oldest week to now</returns>
        IObservable<Participation> GetParticipation(string owner, string name);

        /// <summary>
        /// Returns a list of the number of commits per hour in each day
        /// </summary>
        /// <param name="owner">The owner of the repository</param>
        /// <param name="name">The name of the repository</param>
        /// <returns>Returns commit counts per hour in each day</returns>
        IObservable<PunchCard> GetPunchCard(string owner, string name);
    }
}