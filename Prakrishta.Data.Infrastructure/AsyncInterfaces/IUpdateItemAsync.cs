﻿//----------------------------------------------------------------------------------
// <copyright file="IUpdateItemAsync.cs" company="Prakrishta Technologies">
//     Copyright (c) 2019 Prakrishta Technologies. All rights reserved.
// </copyright>
// <author>Arul Sengottaiyan</author>
// <date>2/16/2019</date>
// <summary>Contract that defines methods to update items</summary>
//-----------------------------------------------------------------------------------

namespace Prakrishta.Data.Cosmos.Infrastructure.AsyncInterfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// THe interface for update methods
    /// </summary>
    /// <typeparam name="TEntity">The entity type</typeparam>
    /// <typeparam name="TIdentity">The input type</typeparam>
    public interface IUpdateItemAsync<in TIdentity, TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Update record with modified details
        /// </summary>
        /// <param name="id">The identity field</param>
        /// <param name="entity">The modified entity</param>
        /// <returns>The updated entity</returns>
        Task<TEntity> UpdateAsync(TIdentity id, TEntity entity);
    }

    /// <summary>
    /// THe interface for update methods
    /// </summary>
    /// <typeparam name="TEntity">The entity type</typeparam>
    public interface IUpdateItemAsync<TEntity> where TEntity : class
    {
        /// <summary>
        /// Update record with modified details
        /// </summary>
        /// <param name="entity">The modified entity</param>
        /// <returns>The updated entity</returns>
        Task<TEntity> UpdateAsync(TEntity entity);
    }

    /// <summary>
    /// The interface for update collection of records
    /// </summary>
    /// <typeparam name="TEntity">The entity type</typeparam>
    public interface IUpdateCollectionAsync<TEntity> where TEntity : class
    {
        /// <summary>
        /// Update collection of entities
        /// </summary>
        /// <param name="entities">The list of modified entities</param>
        /// <returns>The awaitable task</returns>
        Task UpdateAsync(IEnumerable<TEntity> entities);
    }
}
