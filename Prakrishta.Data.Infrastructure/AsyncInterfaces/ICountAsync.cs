//----------------------------------------------------------------------------------
// <copyright file="ICountAsync.cs" company="Prakrishta Technologies">
//     Copyright (c) 2019 Prakrishta Technologies. All rights reserved.
// </copyright>
// <author>Arul Sengottaiyan</author>
// <date>2/15/2019</date>
// <summary>Contract that defines methods for getting record count</summary>
//-----------------------------------------------------------------------------------

using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Prakrishta.Data.Cosmos.Infrastructure.AsyncInterfaces
{
    /// <summary>
    /// Interface that has count methods
    /// </summary>
    public interface ICountAsync
    {
        /// <summary>
        /// Gets record count async
        /// </summary>
        /// <returns>Number of records</returns>
        Task<int> GetCountAsync();
    }

    /// <summary>
    /// Interface that has count methods
    /// </summary>
    /// <typeparam name="TEntity">The type of entity</typeparam>
    public interface ICountAsync<TEntity> where TEntity : class
    {
        /// <summary>
        /// Gets record count async
        /// </summary>
        /// <param name="predicate">The filter condition</param>
        /// <returns>Number of records</returns>
        Task<int> GetCountAsync(Expression<Func<TEntity, bool>> predicate);
    }

    /// <summary>
    /// Interface that has count methods
    /// </summary>
    /// <typeparam name="TIdentity">The identity key type</typeparam>
    public interface ICountByKeyAsync<in TIdentity>
    {
        /// <summary>
        /// Gets record count async by Id
        /// </summary>
        /// <param name="id">The identity key</param>
        /// <returns>Number of records</returns>
        Task<int> GetCountAsync(TIdentity id);
    }
}
