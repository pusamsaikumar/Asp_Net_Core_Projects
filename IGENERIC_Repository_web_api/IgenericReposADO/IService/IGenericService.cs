namespace IgenericReposADO.IService
{
    public interface IGenericService <T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);  
        List<T>Insert(T item);
        List<T> Edit(T item);

        List<T> Delete(int id);
    }
}
