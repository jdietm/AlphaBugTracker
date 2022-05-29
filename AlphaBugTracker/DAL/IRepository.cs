namespace AlphaBugTracker.DAL
{
    public interface IRepository<T> where T : class
    {
        ICollection<T>? GetList(Func<T, bool>? whereFunction);
        ICollection<T>? GetListOrdered(string orderCriteria);
        T? Get(Func<T, bool>? firstFunction);
        T? GetById(int? id);
        void Create(T? entity);
        void Update(int? id);
        void Delete(int? id);
        void Save();

    }
}
