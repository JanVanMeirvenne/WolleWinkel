using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using shared.interfaces;

namespace server.core.interfaces
{
    public interface IRepository 
    {
        Task<IEnumerable<T>> List<T>(Expression<Func<T,bool>> predicate = null) where T:IEntity;
        Task<T> Get<T>(string id) where T:IEntity;
        Task<T> Upsert<T>(T item) where T:IEntity;
        Task Delete<T>(T item) where T:IEntity;
    }
}