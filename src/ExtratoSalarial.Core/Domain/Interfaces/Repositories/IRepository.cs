namespace ExtratoSalarial.Core.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
    }
}
