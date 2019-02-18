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
            this.Initialization = this.InitializeAsync();
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
        public Task Initialization { get; }

        /// <summary>
        /// Creates collection if the collection doesn't exist with given collection id in the given database 
        /// </summary>
        /// <returns>Task that is awaitable</returns>
        protected async Task CreateCollectionIfNotExistsAsync(Database database)
        {
            await this.Client.CreateDocumentCollectionIfNotExistsAsync(database.SelfLink
                , new DocumentCollection { Id = this.CollectionId }, this.RequestOptions);
        }

        /// <summary>
        /// Creates database if the database doesn't exist with given database id 
        /// </summary>
        /// <returns>Task that is awaitable</returns>
        protected async Task<Database> CreateDatabaseIfNotExistsAsync()
        {
            return await this.Client.CreateDatabaseIfNotExistsAsync(new Database { Id = this.DatabaseId }, this.RequestOptions);
        }

        /// <summary>
        /// Async initialization to create database and collection if not exists
        /// </summary>
        /// <returns></returns>
        private async Task InitializeAsync()
        {
            var database = this.CreateDatabaseIfNotExistsAsync();
            database.Wait();
            await this.CreateCollectionIfNotExistsAsync(database.Result);
        }
    }
}
