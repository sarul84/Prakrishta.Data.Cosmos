using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Microsoft.Extensions.Configuration;
using Prakrishta.Data.Cosmos.Sql.Implementations;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Prakristha.Data.Cosmos.Sql.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncMain(args).GetAwaiter().GetResult();
        }

        static async Task AsyncMain(string[] args)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();
            var client = new DocumentClient(new Uri(configuration.GetSection("CosmosDbSettings")["connectionUrl"]),
                configuration.GetSection("CosmosDbSettings")["password"]);

            var databaseId = configuration.GetSection("CosmosDbSettings")["database"];
            var collectionId = configuration.GetSection("CosmosDbSettings")["collection"];

            //var curdRepository = new CrudRepository<Item>(databaseId, collectionId, client);

            //Item item = new Item { Name = "Test1", Description = "Testing Cosmo DB", Completed = false };

            //var newDocument = await curdRepository.AddAsync(item);
            //Console.WriteLine($"Document Created, Id:{newDocument.Id}");

            var count = await GetCountAsync(client, databaseId, collectionId);
            Console.WriteLine($"Document count:{count}");

            Console.ReadLine();
        }

        public static Task<int> GetCountAsync(IDocumentClient client, string dbId, string collId,
            CancellationToken token = default(CancellationToken))
        {
            FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };

            if (token.IsCancellationRequested)
            {
                throw new TaskCanceledException("The task has been cancelled");
            }

            IQueryable<dynamic> query = client.CreateDocumentQuery<dynamic>(UriFactory.CreateDocumentCollectionUri(dbId, collId),
                                                "SELECT VALUE COUNT(1) FROM c", queryOptions);
            foreach (dynamic count in query)
            {
                return Task.FromResult<int>((int)count);
            }
            return Task.FromResult(0);
        }
    }
}
