//----------------------------------------------------------------------------------
// <copyright file="IDeleteItemAsync.cs" company="Prakrishta Technologies">
//     Copyright (c) 2019 Prakrishta Technologies. All rights reserved.
// </copyright>
// <author>Arul Sengottaiyan</author>
// <date>2/16/2019</date>
// <summary>The contract that defines methods for deleting records</summary>
//-----------------------------------------------------------------------------------

namespace Prakrishta.Data.Cosmos.Infrastructure.AsyncInterfaces
{
    using System;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface that has methods for deleting records
    /// </summary>
    /// <typeparam name="TEntity">The entity type</typeparam>
    public interface IDeleteItemAsync<TEntity> where TEntity : class
    {
        /// <summary>
        /// Delete an item
        /// </summary>
        /// <param name="predicate">The filter criteria</param>
        /// <returns>The awaitable task</returns>
        Task DeleteAsync(Expression<Func<TEntity, bool>> predicate);
    }

    /// <summary>
    /// Interface that has methods for deleting records
    /// </summary>
    /// <typeparam name="TIdentity">The identity type</typeparam>
    public interface IDeleteItemByIdAsync<in TIdentity>
    {
        /// <summary>
        /// Delete an item
        /// </summary>
        /// <param name="id">Identity key</param>
        /// <returns>The awaitable task</returns>
        Task DeleteAsync(TIdentity id);
    }

    /// <summary>
    /// Interface that has methods for deleting records
    /// </summary>
    /// <typeparam name="TIdentity1">The identity type</typeparam>
    /// /// <typeparam name="TIdentity2">The identity type</typeparam>
    public interface IDeleteItemByIdAsync<in TIdentity1, in TIdentity2>
    {
        /// <summary>
        /// Delete an item
        /// </summary>
        /// <param name="id1">Identity key 1</param>
        /// <param name="id2">Identity key 2</param> 
        /// <returns>The awaitable task</returns>
        Task DeleteAsync(TIdentity1 id1, TIdentity2 id2);
    }
}
