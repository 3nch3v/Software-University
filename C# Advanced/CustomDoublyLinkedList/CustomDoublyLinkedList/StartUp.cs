using System;

namespace CustomDoublyLinkedList
{
    class StartUp
    {
        static void Main(string[] args)
        {
            DoublyLinkedList list = new DoublyLinkedList();

            list.AddFirst(44);
            list.AddFirst(22);
            list.AddFirst(111111);

            list.AddLast(1);
            list.AddLast(11);
            list.AddLast(111);

            int[] arr = list.ToArray();

            list.RemoveFirst();
            list.RemoveLast();

            list.ForEach(n => Console.WriteLine(n));
        }
    }
}
