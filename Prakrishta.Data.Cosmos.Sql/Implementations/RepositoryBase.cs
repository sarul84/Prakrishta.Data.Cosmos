//----------------------------------------------------------------------------------
// <copyright file="RepositoryBase.cs" company="Prakrishta Technologies">
//     Copyright (c) 2019 Prakrishta Technologies. All rights reserved.
// </copyright>
// <author>Arul Sengottaiyan</author>
// <date>2/15/2019</date>
// <summary>Base class for document db repositories</summary>
//-----------------------------------------------------------------------------------

namespace Prakrishta.Data.Cosmos.Sql.Implementations
{
    using Microsoft.Azure.Documents;
    using Microsoft.Azure.Documents.Client;
    using Prakrishta.Data.Cosmos.Infrastructure.AsyncInterfaces;
    using System.Threading.Tasks;

    /// <summary>
    /// Base class for document db
    /// </summary>
    public abstract class RepositoryBase : IAsyncInitialization
    {
        /// <summary>
        /// Initializes a new instances of <see cref="RepositoryBase"/> class
        /// </summary>
        /// <param name="databaseId">The database id</param>
        /// <param name="collectionId">The collection id</param>
        /// <param name="client">The document client</param>
        /// <param name="requestOptions">The request options</param>
        public RepositoryBase(string databaseId, string collectionId, IDocumentClient client, RequestOptions requestOptions)
        {
            this.DatabaseId = databaseId;
            this.CollectionId = collectionId;
            this.Client = client;
            this.RequestOptions = requestOptions;
            this.Initialization = this.CreateDatabaseIfNotExistsAsync();
        }

        /// <summary>
        /// Gets or sets database id
        /// </summary>
        public string DatabaseId { get; set; }

        /// <summary>
        /// Gets or sets collection id
        /// </summary>
        public string CollectionId { get; set; }

        /// <summary>
        /// Gets or sets Document client object
        /// </summary>
        protected IDocumentClient Client { get; set; }

        /// <summary>
        /// Gets or sets Document client object
        /// </summary>
        protected RequestOptions RequestOptions { get; set; }

        /// <summary>
        /// Gets or sets the result of the asynchronous initialization of this instance.
        /// </summary>
        public Task Initialization { get; protected set; }

        /// <summary>
        /// Creates collection if the collection doesn't exist with given collection id in the given database 
        /// </summary>
        /// <returns>Task that is awaitable</returns>
        protected async Task CreateCollectionIfNotExistsAsync()
        {
            await this.Client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(this.DatabaseId)
                , new DocumentCollection { Id = this.CollectionId }, this.RequestOptions);
        }

        /// <summary>
        /// Creates database if the database doesn't exist with given database id 
        /// </summary>
        /// <returns>Task that is awaitable</returns>
        private async Task CreateDatabaseIfNotExistsAsync()
        {
            await this.Client.CreateDatabaseIfNotExistsAsync(new Database { Id = this.DatabaseId }, this.RequestOptions);
        }
    }
}
