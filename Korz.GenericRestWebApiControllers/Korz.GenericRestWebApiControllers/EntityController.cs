using System.Web.Http;
using GenericRavenDataInterfaces;

namespace GenericRestWebApiControllers
{
    public abstract class EntityController<TEntity, TEntityCriteria, TEntityDataFactory> : ApiController
        where TEntity : IEntity
        where TEntityCriteria : ISingleCriteriaEntity
        where TEntityDataFactory : IDataFactory<TEntity, TEntityCriteria>
    {
        private readonly TEntityDataFactory _factory;

        protected EntityController(TEntityDataFactory factory)
        {
            _factory = factory;
        }

        public TEntity Get()
        {
            return _factory.New();
        }

        public TEntity Get(string id)
        {
            return _factory.Load(id);
        }

        public TEntity Post([FromBody]TEntity entity)
        {
            return _factory.Create(entity);
        }

        public TEntity Put(string id, [FromBody]TEntity entity)
        {
            return _factory.Update(id, entity);
        }

        public void Delete([FromUri]string id)
        {
            _factory.Delete(id);
        }
    }
}