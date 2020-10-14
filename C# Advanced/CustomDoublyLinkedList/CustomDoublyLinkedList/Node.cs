
namespace CustomDoublyLinkedList
{
    class Node
    {
        public Node(int value)
        {
            this.Value = value;
        }

        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node PreviousNode { get; set; }
    }
}
