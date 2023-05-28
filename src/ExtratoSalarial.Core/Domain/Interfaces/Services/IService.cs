namespace ExtratoSalarial.Core.Domain.Interface.Services
{
    public interface IService<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
    }
}
