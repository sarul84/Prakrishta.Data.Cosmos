//----------------------------------------------------------------------------------
// <copyright file="ICrudRepository.cs" company="Prakrishta Technologies">
//     Copyright (c) 2019 Prakrishta Technologies. All rights reserved.
// </copyright>
// <author>Arul Sengottaiyan</author>
// <date>2/15/2019</date>
// <summary>Contract that defines CRUD operations</summary>
//-----------------------------------------------------------------------------------

namespace Prakrishta.Data.Cosmos.Sql.Interfaces
{
    using Microsoft.Azure.Documents;
    using Prakrishta.Data.Cosmos.Infrastructure.AsyncInterfaces;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface that has definitions for CRUD operations
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface ICrudRepository<TEntity> : IReadRepository<TEntity>, IAddItemAsync<TEntity, Document>, IUpdateItemAsync<string, TEntity, Document>
        , IUpdateItemAsync<Document>, IDeleteItemByIdAsync<string, Document>, IDeleteAllItemsAsync<DocumentCollection>
        where TEntity : class
    {
        /// <summary>
        /// Adds if absent or updates if present the given entity in the cosmos db store.
        /// </summary>
        /// <param name="id">The primary key</param>
        /// <param name="entity">The entity to upsert</param>
        /// <param name="token">The CancellationToken for this operation.</param>
        /// <returns>A task that represents the asynchronous Upsert operation.</returns>
        Task<Document> UpsertAsync(string id, TEntity entity, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Replaces a document collection
        /// </summary>
        /// <param name="collection">The updated document collection.</param>
        /// <returns>The task object representing the service response for the asynchronous operation.</returns>
        Task<DocumentCollection> UpdateCollectionAsync(DocumentCollection collection);

        /// <summary>
        /// Executes a stored procedure against a partitioned collection in the Azure Cosmos DB
        /// </summary>
        /// <param name="storedProcId">The stored procedure id</param>
        /// <param name="token">The CancellationToken for this operation.</param>
        /// <param name="procedureParams">An array of dynamic objects representing the parameters for the stored procedure.</param>
        /// <returns></returns>
        Task<TEntity> ExecuteStoredProcAsync(string storedProcId, CancellationToken token = default(CancellationToken), params object[] procedureParams);
    }
}
