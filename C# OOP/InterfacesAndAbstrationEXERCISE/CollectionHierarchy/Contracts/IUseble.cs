
namespace CollectionHierarchy2.Contracts
{
    public interface IUseble<T> : IRemoveble<T>
    {
        int Count { get; }
    }
}
