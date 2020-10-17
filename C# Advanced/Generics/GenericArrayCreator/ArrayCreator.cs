
namespace GenericArrayCreator
{
    public class ArrayCreator
    {
        public static T[] Create<T>(int length, T element)
        {
            var newArr = new T[length];

            for (int i = 0; i < length; i++)
            {
                newArr[i] = element;
            }

            return newArr;
        }
    }
}
