namespace ClubManagmentSystem.Repo.Interfaces
{
    public interface IGenericRepo<T>
    {
        List<T> GetAll();
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);
        T GetById(int id);
        void Save();
    }
}
