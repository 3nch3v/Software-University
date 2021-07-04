using Problem03.Queue;
using Problem04.SinglyLinkedList;
using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedList<int> qqq = new SinglyLinkedList<int>();
            qqq.AddFirst(2);
            qqq.AddFirst(3);
            qqq.AddFirst(4);

            var getlast = qqq.GetLast();
            var removelast = qqq.RemoveLast();
            var getlast1 = qqq.GetLast();
            var removelast2 = qqq.RemoveLast();
            var getlast2 = qqq.GetLast();
            var removelast3 = qqq.RemoveLast();
            var getlast3 = qqq.GetLast();
        }
    }
}
