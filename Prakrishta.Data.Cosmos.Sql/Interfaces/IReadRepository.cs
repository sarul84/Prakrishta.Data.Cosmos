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
    }
}
