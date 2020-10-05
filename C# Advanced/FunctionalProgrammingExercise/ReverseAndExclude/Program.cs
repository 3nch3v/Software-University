using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbersList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Reverse()
                .ToList();

            int number = int.Parse(Console.ReadLine());

            numbersList = NumbersFilter(numbersList, number);
            Console.WriteLine(string.Join(" ", numbersList));
        }

        static List<int> NumbersFilter(List<int> nums, int num)
        {
            Predicate<int> pre = n => n % num == 0;

            for (int i = 0; i < nums.Count; i++)
            {
                if (pre(nums[i]))
                {
                    nums.Remove(nums[i]);
                    i--;
                }
            }

            return nums;
        }
    }
}
