using System.Collections.Generic;

namespace Andromeda.InstaTwoApi.Api.Models
{
    
    public class PaginatedModel<TEntity> where TEntity : class
    {
        public int PageIndex { get;}
         
        public int PageSize { get; }
         
        public long Count { get; }
         
        public IEnumerable<TEntity> Data { get;}
         
        public PaginatedModel(int pageIndex, int pageSize, long count, IEnumerable<TEntity> data)
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.Count = count;
            this.Data = data;
        }
    }
}