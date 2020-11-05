
namespace CollectionHierarchy2.Contracts
{
    public interface IRemoveble<T> : IAddble<T>
    {
        T Remove();
    }
}
