using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos.Table;
using server.core.interfaces;
using shared.interfaces;

namespace server.infra.data
{
    public class Repository : IRepository
    {
        private readonly CloudTableClient _cloudTableClient;

        public Repository(IRepositorySettings dataSettings)
        {
            var storageAccount =  CloudStorageAccount.Parse(dataSettings.ConnectionString);
            _cloudTableClient = storageAccount.CreateCloudTableClient();

        }

        private async Task<CloudTable> GetTable<T>()
        {
            var table = _cloudTableClient.GetTableReference(nameof(T));
            await table.CreateIfNotExistsAsync();
            return table;

        }

        public async Task<IEnumerable<>> List<T>(string filter = null) where T:IEntity
        {
            var table = await GetTable<T>();
            TableQuery<DynamicTableEntity> query = null;
            if (!string.IsNullOrEmpty(filter))
            {
                query = new TableQuery<DynamicTableEntity>()
                {
                    FilterString = filter
                };
            }
            else
            {
                query = new TableQuery<DynamicTableEntity>();
            }
            
            var result = await table.ExecuteQuerySegmentedAsync<DynamicTableEntity>(query, null);
            return result.Results.Select(o => EntityPropertyConverter.ConvertBack<T>(o.Properties,null));
        }

        public async Task<T> Get<T>(string id) where T:IEntity
        {
            var table = await GetTable<T>();
            var query = new TableQuery<DynamicTableEntity>()
            {
                FilterString = $"Id eq '{id}'"
            };
            var result = await table.ExecuteQuerySegmentedAsync<DynamicTableEntity>(query, null);
            return result.Results.Select(o => EntityPropertyConverter.ConvertBack<T>(o.Properties,null)).FirstOrDefault();
        }

        public async Task<T> Upsert<T>(T item) where T:IEntity
        {
            var table = await GetTable<T>();
            var createOperation = TableOperation.InsertOrReplace(Flatten(item));
            var result = await table.ExecuteAsync(createOperation);
            return item;
        }

        public async Task Delete<T>(T item) where T:IEntity
        {
            var table = await GetTable<T>();
            var deleteOperation =
                TableOperation.Delete(Flatten(item));
            await table.ExecuteAsync(deleteOperation);
        }

        private DynamicTableEntity Flatten(IEntity item)
        {
            Dictionary<string, EntityProperty> flattenedProperties = EntityPropertyConverter.Flatten(item,null);
            DynamicTableEntity dynamicTableEntity = new DynamicTableEntity(Guid.Empty.ToString(), item.Id)
            {
                Properties = flattenedProperties
            };

            return dynamicTableEntity;


        }

        
    }
}