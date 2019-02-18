//----------------------------------------------------------------------------------
// <copyright file="ReadRepository.cs" company="Prakrishta Technologies">
//     Copyright (c) 2019 Prakrishta Technologies. All rights reserved.
// </copyright>
// <author>Arul Sengottaiyan</author>
// <date>2/15/2019</date>
// <summary>Class that implements read repository</summary>
//-----------------------------------------------------------------------------------

namespace Prakrishta.Data.Cosmos.Sql.Implementations
{
    using Microsoft.Azure.Documents;
    using Microsoft.Azure.Documents.Client;
    using Microsoft.Azure.Documents.Linq;
    using Prakrishta.Data.Cosmos.Sql.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Net;
    using System.Threading.Tasks;

    /// <summary>
    /// Class that has read only methods to cosmos document db
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public class ReadRepository<TEntity> : RepositoryBase, IReadRepository<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Initializes a new instances of <see cref="ReadRepository"/> class.
        /// </summary>
        /// <param name="databaseId">The database id</param>
        /// <param name="collectionId">The collection id</param>
        /// <param name="client">The document database client</param>
        public ReadRepository(string databaseId, string collectionId, IDocumentClient client)
            : base(databaseId, collectionId, client)
        {
        }

        /// <summary>
        /// Initializes a new instances of <see cref="ReadRepository"/> class.
        /// </summary>
        /// <param name="databaseId">The database id</param>
        /// <param name="collectionId">The collection id</param>
        /// <param name="client">The document database client</param>
        /// <param name="requestOptions">The request options</param>
        public ReadRepository(string databaseId, string collectionId, IDocumentClient client, RequestOptions requestOptions)
            : base(databaseId, collectionId, client, requestOptions)
        {
        }

        /// <inheritdoc />
        public async Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            IDocumentQuery<TEntity> query = this.Client.CreateDocumentQuery<TEntity>(
                UriFactory.CreateDocumentCollectionUri(this.DatabaseId, this.CollectionId))
                .Where(predicate)
                .AsDocumentQuery();

            List<TEntity> results = new List<TEntity>();
            if (query.HasMoreResults)
            {
                results.AddRange(await query.ExecuteNextAsync<TEntity>());
            }

            return results;
        }

        /// <inheritdoc />
        public async Task<DocumentCollection> GetAllAsync()
        {
            return await this.Client.ReadDocumentCollectionAsync(UriFactory.CreateDocumentCollectionUri(this.DatabaseId, this.CollectionId),
                this.RequestOptions);
        }

        /// <inheritdoc />
        public async Task<TEntity> GetAsync(string id)
        {
            var documentResponse = await this.Client.ReadDocumentAsync<TEntity>(
                UriFactory.CreateDocumentUri(this.DatabaseId, this.CollectionId, id),
                this.RequestOptions);

            if (documentResponse?.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            return documentResponse.Document as TEntity;
        }

        /// <inheritdoc />
        public async Task<int> GetCountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            IDocumentQuery<TEntity> query = this.Client.CreateDocumentQuery<TEntity>(
                UriFactory.CreateDocumentCollectionUri(this.DatabaseId, this.CollectionId))
                .Where(predicate)
                .AsDocumentQuery();

            if (query.HasMoreResults)
            {
                var result = await query.ExecuteNextAsync<TEntity>();
                return result.Count;
            }

            return 0;
        }
    }
}
