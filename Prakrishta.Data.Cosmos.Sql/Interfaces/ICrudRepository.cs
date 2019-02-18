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
    using Prakrishta.Data.Cosmos.Infrastructure.AsyncInterfaces;

    /// <summary>
    /// Interface that has definitions for CRUD operations
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface ICrudRepository<TEntity, TResult> : IReadRepository<TEntity>, IAddItemAsync<TEntity, TResult>, IUpdateItemAsync<TEntity>
        where TEntity : class
        where TResult : class
    {

    }
}
