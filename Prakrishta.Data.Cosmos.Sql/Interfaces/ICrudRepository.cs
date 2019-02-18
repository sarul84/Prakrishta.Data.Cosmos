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
    using System.Threading.Tasks;

    /// <summary>
    /// Interface that has definitions for CRUD operations
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface ICrudRepository<TEntity> : IReadRepository<TEntity>, IAddItemAsync<TEntity, Document>, IUpdateItemAsync<string, TEntity, Document>
        , IUpdateItemAsync<Document>, IDeleteItemByIdAsync<string, Document>, IDeleteAllItemsAsync<DocumentCollection>
        where TEntity : class
    {
    }
}
