using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Praxent.Core.IQueryable;
using Praxent.Core.IQueryable.Model;
using Praxent.Data;
using Praxent.Service;

namespace Praxent.API.Server.Controllers.Base
{
    public abstract class BaseReadController<T> : BaseController where T : class, IDataEntity, new()
    {
        protected readonly IBasicDataService<T> _dataService;
        protected readonly IQueryProcessor _queryProcessor;

        public BaseReadController(IBasicDataService<T> dataService,
            IQueryProcessor queryProcessor)
        {
            _dataService = dataService;
            _queryProcessor = queryProcessor;
        }

        // GET api/{type}
        [HttpGet]
        public virtual IQueryable<T> GetAll([FromQuery] URLQuery query)
        {
            return _queryProcessor.ProcessURLQueryForIQueryable(_dataService.GetAll(), query);
        }

        // GET api/{type}/{id}
        [HttpGet("{id}")]
        public virtual T Get(string id)
        {
            return _dataService.GetById(id);
        }

        // GET api/{type}/count
        [HttpGet]
        [Route("count")]
        public virtual int Count()
        {
            return _dataService.GetAll().Count();
        }
    }
}