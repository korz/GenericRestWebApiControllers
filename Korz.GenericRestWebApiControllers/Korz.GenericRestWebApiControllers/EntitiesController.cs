using System.Collections.Generic;
using System.Web.Http;
using Korz.GenericRavenDataInterfaces;

namespace Korz.GenericRestWebApiControllers
{
    public abstract class EntitiesController<TEntity, TEntityCriteria, TEntityDataFactory> : ApiController
        where TEntity : IEntity
        where TEntityCriteria : ISingleCriteriaEntity
        where TEntityDataFactory : IDataFactory<TEntity, TEntityCriteria>
    {
        private readonly TEntityDataFactory _factory;

        protected EntitiesController(TEntityDataFactory factory)
        {
            _factory = factory;
        }

        public IEnumerable<TEntity> Get()
        {
            return _factory.Load();
        }

        public IEnumerable<TEntity> Get([FromBody]TEntityCriteria criteria)
        {
            return _factory.Load(criteria);
        }
    }
}