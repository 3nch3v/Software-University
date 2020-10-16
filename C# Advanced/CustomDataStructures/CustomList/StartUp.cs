using System;

namespace CustomList
{
    class StartUp
    {
        static void Main(string[] args)
        {
            CustomList list = new CustomList();

            list.AddItem(6);
            list.AddItem(63);
            list.AddItem(634);
            list.AddItem(62342);
            list.AddItem(1232346);
            list.AddItem(54665886);

            //int num = list[2];
            //list[5] = 111;

            //list.RemoveAt(0);
            //list.RemoveAt(2);
            //list.RemoveAt(3);
            //list.RemoveAt(11);

            list.InsertAt(1, 5555);
            bool element = list.Contains(62342);
            list.Swap(7, 1);
        }
    }
}
