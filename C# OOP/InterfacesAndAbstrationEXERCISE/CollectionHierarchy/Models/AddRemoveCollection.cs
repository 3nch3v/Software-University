
using CollectionHierarchy2.Contracts;

namespace CollectionHierarchy2.Models
{
    public class AddRemoveCollection<T> : AddCollection<T>, IRemoveble<T>
    {
        private const int AddAtIndex = 0;

        public override int Add(T element)
        {
            this.Data.Insert(AddAtIndex, element);
            return AddAtIndex;
        }

        public virtual T Remove()
        {
            T element = this.Data[this.Data.Count - 1];
            this.Data.RemoveAt(this.Data.Count - 1);

            return element;
        }
    }
}
