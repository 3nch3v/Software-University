namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BalancedParenthesesSolve : ISolvable
    {
        private static char[] openParentheseTypes = new[] { '(', '[', '{' };
        private static char[] closeParentheseTypes = new[] { ')', ']', '}' };

        public bool AreBalanced(string parentheses)
        {
            Stack<char> openParentheses = new Stack<char>();
           
            for (int i = 0; i < parentheses.Length; i++)
            {
                char currParenthese = parentheses[i];

                if (openParentheseTypes.Contains(currParenthese))
                {
                    openParentheses.Push(currParenthese);
                }
                else if (closeParentheseTypes.Contains(currParenthese))
                {
                    if (openParentheses.Count == 0)
                    {
                        return false;
                    }

                    var openParenthese = openParentheses.Peek();

                    if ((openParenthese == '(' && currParenthese == ')') 
                        || (openParenthese == '{' && currParenthese == '}')
                        || (openParenthese == '[' && currParenthese == ']'))
                    {
                        openParentheses.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return openParentheses.Count == 0;
        }
    }
}
