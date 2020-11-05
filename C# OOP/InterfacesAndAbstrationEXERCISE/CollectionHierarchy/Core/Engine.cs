
using CollectionHierarchy2.Contracts;
using CollectionHierarchy2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy2.Core
{
    public class Engine
    {
        private AddCollection<string> addCollection;
        private AddRemoveCollection<string> addRemoveCollection;
        private MyList<string> myList;

        private StringBuilder outputResult;

        public Engine()
        {
            addCollection = new AddCollection<string>();
            addRemoveCollection = new AddRemoveCollection<string>();
            myList = new MyList<string>();

            outputResult = new StringBuilder();
        }


        public void Run()
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            FillCollection(input, addCollection);
            FillCollection(input, addRemoveCollection); 
            FillCollection(input, myList);

            int removeNumberOfElements = int.Parse(Console.ReadLine());

            RemoveElement(removeNumberOfElements, addRemoveCollection);
            RemoveElement(removeNumberOfElements, myList);

            Console.WriteLine(outputResult.ToString().Trim());
        }


        private void FillCollection(string[] input, IAddble<string> collection)
        {
            foreach (var item in input)
            {
                int index = collection.Add(item);
                outputResult.Append(index + " ");
            }

            outputResult.AppendLine();   //.Remove(this.outputResult.Length - 1, 1)
        }

        private void RemoveElement(int countOfElements, IRemoveble<string> collection)
        {
            for (int i = 0; i < countOfElements; i++)
            {
                string returnElement = collection.Remove();

                outputResult.Append(returnElement + " ");
            }

            outputResult.AppendLine();
        }
    }
}
