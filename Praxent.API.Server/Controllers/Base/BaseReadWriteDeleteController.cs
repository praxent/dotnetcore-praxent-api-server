using Microsoft.AspNetCore.Mvc;
using Praxent.Core.IQueryable;
using Praxent.Data;
using Praxent.Service;

namespace Praxent.API.Server.Controllers.Base
{
    public class BaseReadWriteDeleteController<T> : BaseReadWriteController<T> where T : class, IDataEntity, new()
    {
        public BaseReadWriteDeleteController(IBasicDataService<T> dataService, IQueryProcessor queryProcessor) : base(dataService, queryProcessor)
        {
        }

        // DELETE api/{type}/{id}
        [HttpDelete("{id}")]
        public virtual T Delete(string id)
        {
            return _dataService.Delete(id);
        }
    }
}