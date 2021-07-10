namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Tree<T> : IAbstractTree<T>
    {
        private bool isRootDeleted;

        private readonly List<Tree<T>> children;

        public Tree(T value)
        {
            this.Value = value;
            this.children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            this.Value = value;
            this.children = children.ToList();
            SetParent(children);
        }

        public T Value { get; private set; }

        public Tree<T> Parent { get; private set; }

        public IReadOnlyCollection<Tree<T>> Children => this.children.AsReadOnly();

        public ICollection<T> OrderBfs()
        {
            ICollection<T> orderBfs = new List<T>();

            if (isRootDeleted)
            {
                return orderBfs;
            }

            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                orderBfs.Add(node.Value);

                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return orderBfs;
        }

        public ICollection<T> OrderDfs()
        {
            List<T> orderDfs = new List<T>();

            if (isRootDeleted)
            {
                return orderDfs;
            }

            orderDfs = GetDfsResult(this);
            return orderDfs;
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            var parentNode = GetNode(parentKey);

            if (parentNode == null)
            {
                throw new ArgumentNullException();
            }

            parentNode.children.Add(child);
        }

        public void RemoveNode(T nodeKey)
        {
            var node = GetNode(nodeKey);

            if (node == null)
            {
                throw new ArgumentNullException();
            }

            var parentNode = node.Parent;

            if (parentNode == null)
            {
                this.children.Clear();
                this.Value = default;
                isRootDeleted = true;
            }
            else
            {
                parentNode.children.Remove(node);
            }
        }

        public void Swap(T firstKey, T secondKey)
        {
            Tree<T> firstNode = GetNode(firstKey);
            Tree<T> secondNode = GetNode(secondKey);

            if (firstNode == null || secondNode == null)
            {
                throw new ArgumentNullException();
            }

            var firstNodeParent = firstNode.Parent;
            var secondNodeParent = secondNode.Parent;

            if (firstNodeParent == null)
            {
                this.Swap(firstNode, secondNode);
            }
            else if (secondNodeParent == null) 
            {
                this.Swap(secondNode, firstNode);
            }
            else
            {
                var indexOfFirstNode = firstNodeParent.children.IndexOf(firstNode);
                var indexOfFSecondNode = secondNodeParent.children.IndexOf(secondNode);

                firstNodeParent.children[indexOfFirstNode] = secondNode;
                secondNodeParent.children[indexOfFSecondNode] = firstNode;
            }        
        }

        private void Swap(Tree<T> root, Tree<T> node)
        {
            root.Value = node.Value;
            root.children.Clear();
            root.children.AddRange(node.children);
        }

        private Tree<T> GetNode(T value)
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var currNode = queue.Dequeue();

                if (currNode.Value.Equals(value))
                {
                    return currNode;
                }

                foreach (var currChild in currNode.Children)
                {
                    queue.Enqueue(currChild);
                }
            }

            return null;
        }

        private void SetParent(Tree<T>[] children)
        {
            foreach (var currChild in children)
            {
                currChild.Parent = this;
            }
        }

        private List<T> GetDfsResult(Tree<T> node)
        {
            List<T> result = new List<T>();

            foreach (var currchild in node.Children)
            {
                result.AddRange(GetDfsResult(currchild));
            };

            return result;
        }
    }
}
