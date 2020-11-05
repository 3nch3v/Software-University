
using CollectionHierarchy2.Contracts;

namespace CollectionHierarchy2.Models
{
    public class MyList<T> : AddRemoveCollection<T>, IUseble<T>
    {
        private const int RemoveAtIndex = 0;

        public int Count => this.Data.Count;

        public override T Remove()
        {
            T item = this.Data[RemoveAtIndex];
            this.Data.RemoveAt(RemoveAtIndex);

            return item;
        }
    }
}
