
using System.Collections;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class BookComparator : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            int compare = x.Title.CompareTo(y.Title);

            if (compare == 0)
            {
                compare = y.Year.CompareTo(x.Year);

            }

            return compare;
        }
    }
}
