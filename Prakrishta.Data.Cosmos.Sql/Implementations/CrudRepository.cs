//----------------------------------------------------------------------------------
// <copyright file="CrudRepository.cs" company="Prakrishta Technologies">
//     Copyright (c) 2019 Prakrishta Technologies. All rights reserved.
// </copyright>
// <author>Arul Sengottaiyan</author>
// <date>2/18/2019</date>
// <summary>The class that implements ICrudRepository interface</summary>
//-----------------------------------------------------------------------------------

namespace Prakrishta.Data.Cosmos.Sql.Implementations
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Documents;
    using Microsoft.Azure.Documents.Client;
    using Prakrishta.Data.Cosmos.Sql.Interfaces;

    /// <summary>
    /// Class that definitions for CRUD operations
    /// </summary>
    /// <typeparam name="TEntity">The document entity type</typeparam>
    public sealed class CrudRepository<TEntity> : ReadRepository<TEntity>, ICrudRepository<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Initializes a new instances of <see cref="CrudRepository<>"/> class.
        /// </summary>
        /// <param name="databaseId">The database id</param>
        /// <param name="collectionId">The collection id</param>
        /// <param name="client">The document objecy</param>
        public CrudRepository(string databaseId, string collectionId, IDocumentClient client)
            : this(databaseId, collectionId, client, null)
        {
        }

        /// <summary>
        /// Initializes a new instances of <see cref="CrudRepository<>"/> class.
        /// </summary>
        /// <param name="databaseId">The database id</param>
        /// <param name="collectionId">The collection id</param>
        /// <param name="client">The document database client</param>
        /// <param name="requestOptions">The request options</param>
        public CrudRepository(string databaseId, string collectionId, IDocumentClient client, RequestOptions requestOptions)
            : base(databaseId, collectionId, client, requestOptions)
        {
        }

        /// <inheritdoc />
        public async Task<Document> AddAsync(TEntity entity, CancellationToken token = default(CancellationToken))
        {
            return await this.Client.CreateDocumentAsync(UriFactory.
                CreateDocumentCollectionUri(this.DatabaseId, this.CollectionId), entity, this.RequestOptions, cancellationToken: token);
        }

        /// <inheritdoc />
        public async Task<DocumentCollection> DeleteAllAsync()
        {
            return await this.Client.DeleteDocumentCollectionAsync(UriFactory.
                CreateDocumentCollectionUri(this.DatabaseId, this.CollectionId), this.RequestOptions);
        }

        /// <inheritdoc />
        public async Task<Document> DeleteAsync(string id, CancellationToken token = default(CancellationToken))
        {
            return await this.Client.DeleteDocumentAsync(UriFactory
                .CreateDocumentUri(this.DatabaseId, this.CollectionId, id), this.RequestOptions, token);
        }

        /// <inheritdoc />
        public async Task<Document> UpdateAsync(string id, TEntity entity)
        {
            return await this.Client.ReplaceDocumentAsync(UriFactory.
                CreateDocumentUri(this.DatabaseId, this.CollectionId, id), entity, this.RequestOptions);
        }

        /// <inheritdoc />
        public async Task<Document> UpdateAsync(Document entity)
        {
            return await this.Client.ReplaceDocumentAsync(UriFactory.
                CreateDocumentUri(this.DatabaseId, this.CollectionId, entity.Id), entity, this.RequestOptions);
        }
    }
}
