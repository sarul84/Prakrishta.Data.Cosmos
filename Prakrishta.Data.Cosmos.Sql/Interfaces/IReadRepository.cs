//----------------------------------------------------------------------------------
// <copyright file="IReadRepository.cs" company="Prakrishta Technologies">
//     Copyright (c) 2019 Prakrishta Technologies. All rights reserved.
// </copyright>
// <author>Arul Sengottaiyan</author>
// <date>2/15/2019</date>
// <summary>Contract that defines methods for Read Repository</summary>
//-----------------------------------------------------------------------------------

namespace Prakrishta.Data.Cosmos.Sql.Interfaces
{
    using Prakrishta.Data.Cosmos.Infrastructure.AsyncInterfaces;
    using System;
    using System.Threading.Tasks;
    using System.Linq.Expressions;
    using Microsoft.Azure.Documents;
    using System.Linq;
    using Microsoft.Azure.Documents.Client;
    using System.Threading;

    /// <summary>
    /// Interface that has methods for read only repository
    /// </summary>
    public interface IReadRepository<TEntity> : ISearchSingleAsync<string, TEntity>, ISearchCollectionAsync<TEntity>, ICountAsync<TEntity>, ICountAsync
        where TEntity : class
    {
        /// <summary>
        /// Gets or sets database id
        /// </summary>
        string DatabaseId { get; set; }

        /// <summary>
        /// Gets or sets collection id
        /// </summary>
        string CollectionId { get; set; }

        /// <summary>
        /// Get all the documents from a collection
        /// </summary>
        /// <returns>Collection of documents</returns>
        Task<DocumentCollection> GetAllAsync();

        /// <summary>
        /// Get the queryable collection
        /// </summary>
        /// <param name="take">The number of records to be taken from the result</param>
        /// <param name="skip">The number of records to be skipped from the result before take operation</param>
        /// <param name="feedOptions">The feed options for this operation.</param>
        /// <returns>Returns an IQueryable that matches the expression provided.</returns>
        IQueryable<TEntity> Query(int? take = null, int? skip = null, FeedOptions feedOptions = null);

        /// <summary>
        /// Get the queryable collection
        /// </summary>
        /// <param name="sql">The sql query</param>
        /// <param name="parameters">The sql parameters to replace if any</param>
        /// <param name="take">The number of records to be taken from the result</param>
        /// <param name="skip">The number of records to be skipped from the result before take operation</param>
        /// <param name="feedOptions">The feed options for this operation.</param>
        /// <returns>Returns an IQueryable that matches the expression provided.</returns>
        IQueryable<TEntity> Query(string sql, SqlParameterCollection parameters, int? take = null, int? skip = null, FeedOptions feedOptions = null);

        /// <summary>
        /// Get the Enumerable collection
        /// </summary>
        /// <param name="predicate">The filter condition</param>
        /// <param name="continuationToken">The continuation token from previous result</param>
        /// <param name="take">The number of records to be retrieved</param>
        /// <param name="token">The cancellation token</param>
        /// <returns>The collection of records that matches the filter criteria</returns>
        Task<IFeedResponse<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> predicate, string continuationToken, int? take = null, CancellationToken token = default(CancellationToken));
    }
}
