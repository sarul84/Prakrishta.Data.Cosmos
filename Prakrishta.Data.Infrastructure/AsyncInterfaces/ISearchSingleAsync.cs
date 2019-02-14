﻿//----------------------------------------------------------------------------------
// <copyright file="ISearchSingleAsync.cs" company="Prakrishta Technologies">
//     Copyright (c) 2019 Prakrishta Technologies. All rights reserved.
// </copyright>
// <author>Arul Sengottaiyan</author>
// <date>2/8/2019</date>
// <summary>Contract that defines async method for searching and returning single record</summary>
//-----------------------------------------------------------------------------------

namespace Prakrishta.Data.Cosmos.Infrastructure.AsyncInterfaces
{
    using System;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    /// <summary>
    ///  Generic interface that has method to get single record
    /// </summary>
    /// <typeparam name="TEntity">Entity type that is going to be return</typeparam>
    public interface ISearchSingleAsync<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Get record for the given filter criteria
        /// </summary>
        /// <param name="predicate">Filter criteria</param>
        /// <returns>Returns single record of the expected entity type</returns>
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
    }

    /// <summary>
    ///  Generic interface that has method to get single record
    /// </summary>
    /// <typeparam name="TIdentity">Identity type that is going to be used as a filter</typeparam>
    /// <typeparam name="TEntity">Entity type that is going to be return</typeparam>
    public interface ISearchSingleAsync<in TIdentity, TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Get record for the given id
        /// </summary>
        /// <param name="id">Filter condition</param>
        /// <returns>Returns single record of the expected entity type</returns>
        Task<TEntity> GetAsync(TIdentity id);
    }

    /// <summary>
    /// Generic interface that has method to get single record
    /// </summary>
    /// <typeparam name="TIdentity1">Identity type that is going to be used as a filter</typeparam>
    /// <typeparam name="TIdentity2">Identity type that is going to be used as a filter</typeparam>
    /// <typeparam name="TEntity">Entity type that is going to be return</typeparam>
    public interface ISearchSingleAsync<in TIdentity1, in TIdentity2, TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Get record for the given input parameters
        /// </summary>
        /// <param name="id1">Filter condition1</param>
        /// <param name="id2">Filter condition2</param>
        /// <returns>Returns single record of the expected entity type</returns>
        Task<TEntity> GetAsync(TIdentity1 id1, TIdentity2 id2);
    }

    /// <summary>
    /// Generic interface that has method to get single record
    /// </summary>
    /// <typeparam name="TIdentity1">Identity type that is going to be used as a filter</typeparam>
    /// <typeparam name="TIdentity2">Identity type that is going to be used as a filter</typeparam>
    /// <typeparam name="TIdentity3">Identity type that is going to be used as a filter<</typeparam>
    /// <typeparam name="TEntity">Entity type that is going to be return</typeparam>
    public interface ISearchSingleAsync<in TIdentity1, in TIdentity2, in TIdentity3, TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Get record for the given input parameters
        /// </summary>
        /// <param name="id1">Filter condition1</param>
        /// <param name="id2">Filter condition2</param>
        /// <param name="id3">Filter condition2</param>
        /// <returns>Returns single record of the expected entity type</returns>
        Task<TEntity> GetAsync(TIdentity1 id1, TIdentity2 id2, TIdentity3 id3);
    }
}
