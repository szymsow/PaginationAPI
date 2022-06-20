namespace Pagination.Core
{
    public interface IDataGenerator<T>
    {
        IEnumerable<T> Generate(int count);
    }
}
