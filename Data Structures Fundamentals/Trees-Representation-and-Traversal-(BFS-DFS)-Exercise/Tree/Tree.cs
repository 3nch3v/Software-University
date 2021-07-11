namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> children;

        public Tree(T key, params Tree<T>[] children)
        {
            this.Key = key;
            this.children = children.ToList();
            this.SetParent(this.children);
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }


        public IReadOnlyCollection<Tree<T>> Children
            => this.children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this.children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string GetAsString()
        {
            StringBuilder sb = new StringBuilder();
            GetTreeAsString(sb, this, 0);

            return sb.ToString().Trim();
        }

        public Tree<T> GetDeepestLeftomostNode()
        {
            Tree<T> deepestLeftNode = null;
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var currNode = queue.Dequeue();
                var leftChild = currNode.children.FirstOrDefault();

                if (leftChild == null)
                {
                    deepestLeftNode = currNode;
                    break;
                }

                queue.Enqueue(leftChild);
            }

            return deepestLeftNode;
        }

        public List<T> GetLeafKeys()
        {
            List<T> leafs = new List<T>();
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var currNode = queue.Dequeue();

                if (!currNode.children.Any())
                {
                    leafs.Add(currNode.Key);
                }

                foreach (var child in currNode.children)
                {
                    queue.Enqueue(child);
                }
            }

            return leafs.OrderBy(x => x).ToList();
        }

        public List<T> GetMiddleKeys()
        {
            var middleKeys = new List<T>();
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var currnode = queue.Dequeue();

                if (currnode.Parent != null && currnode.Children.Any())
                {
                    middleKeys.Add(currnode.Key);
                }

                foreach (var child in currnode.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return middleKeys.OrderBy(x => x).ToList();
        }

        public List<T> GetLongestPath()
        {
            Stack<T> pathElements = new Stack<T>();
            var currNode = this.GetDeepestLeftomostNode();

            while (currNode != null)
            {
                pathElements.Push(currNode.Key);
                currNode = currNode.Parent;
            }

            return pathElements.ToList();
        }

        public List<List<T>> PathsWithGivenSum(int sum)
        {
            List<Tree<T>> leafs = new List<Tree<T>>();
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var currNode = queue.Dequeue();

                if (!currNode.Children.Any())
                {
                    leafs.Add(currNode);
                }
                foreach (var child in currNode.Children)
                {
                    queue.Enqueue(child);
                }
            }

            List<List<T>> result = new List<List<T>>();

            foreach (var leaf in leafs)
            {
                Stack<T> currPathKeys = new Stack<T>();
                var currLeaf = leaf;

                while (currLeaf != null)
                {
                    currPathKeys.Push(currLeaf.Key);
                    currLeaf = currLeaf.Parent;
                }

                if (currPathKeys.Sum(x => int.Parse(x.ToString())) == sum)
                {
                    result.Add(currPathKeys.ToList());
                }
            }

            return result;
        }

        public List<Tree<T>> SubTreesWithGivenSum(int sum)
        {
            List<Tree<T>> result = new List<Tree<T>>();
            List<Tree<T>> subTrees = new List<Tree<T>>();
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var currNode = queue.Dequeue();
                subTrees.Add(currNode);
                foreach (var child in currNode.Children)
                {
                    queue.Enqueue(child);
                }
            }

            foreach (var tree in subTrees)
            {
                int currSubTreeSum = 0;
                currSubTreeSum += Convert.ToInt32(tree.Key);

                foreach (var child in tree.children)
                {
                    currSubTreeSum += Convert.ToInt32(child.Key);
                }

                if (currSubTreeSum == sum)
                {
                    result.Add(tree);
                }
            }

            return result;
        }

        private void GetTreeAsString(StringBuilder sb, Tree<T> node, int level)
        {
            string levelPostion = new string(' ', level);
            sb.AppendLine(levelPostion + node.Key);

            foreach (var child in node.Children)
            {
                GetTreeAsString(sb, child, level + 2);
            }
        }

        private void SetParent(List<Tree<T>> childern)
        {
            foreach (var child in children)
            {
                child.Parent = this;
            }
        }
    }
}
