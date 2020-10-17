
namespace GenericScale
{
    class EqualityScale<T>
    {
        private T left;
        private T right;

        public EqualityScale(T left, T right)
        {
            this.left = left;
            this.right = right;
        }

        public bool AreEqual()
        {
            if (this.left.Equals(this.right))
            {
                return true;
            }
            else
            {
                return false;
            }
        
        }
    }
}
