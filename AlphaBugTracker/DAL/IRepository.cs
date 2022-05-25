namespace AlphaBugTracker.DAL
{
    public interface IRepository<T> where T : class
    {
        ICollection<T>? GetList(Func<T, bool>? whereFunction);
        T? Get(Func<T, bool>? firstFunction);
        void Create(T? entity);
        void Update(T? entity);
        void Delete(int? id);
        void Save();

    }
}
