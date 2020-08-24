using Microsoft.AspNetCore.Mvc;
using Praxent.Core.IQueryable;
using Praxent.Data;
using Praxent.Service;

namespace Praxent.API.Server.Controllers.Base
{
    public class BaseReadWriteController<T> : BaseReadController<T> where T : class, IDataEntity, new()
    {
        public BaseReadWriteController(IBasicDataService<T> dataService, IQueryProcessor queryProcessor) : base(dataService, queryProcessor)
        {
        }

        // POST api/{type}
        [HttpPost]
        public virtual T Post([FromBody] T entity)
        {
            return _dataService.Add(entity);
        }

        // PUT api/{type}
        [HttpPut()]
        public virtual T Put([FromBody] T entity)
        {
            return _dataService.Update(entity);
        }
    }
}