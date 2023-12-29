namespace Lab9.Models
{
    public interface IRepository<Type>
      where Type : class
    {
        Task<List<Type>> GetAll();

        Task<Type> GetById(int id);

        Task<Type> Create(Type value);

        Task<Type> Delete(int id);

        Task<Type> Update(int id, Type value);
    }
}
