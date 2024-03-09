using System;
using System.Collections.Generic;

class Program
{
    static bool ValidateParentheses(string input)
    {
        Stack<char> stack = new Stack<char>();

        foreach (char c in input)
        {
            if (c == '(')
            {
                stack.Push(c);
            }
            else if (c == ')')
            {
               
                if (stack.Count == 0 || stack.Pop() != '(')
                {
                    return false;
                }
            }
        }
        return stack.Count == 0;
    }

    static void Main(string[] args)
    {
        string validInput = "(defun factorial (n) (if (= n 0) 1 (* n (factorial (- n 1)))))";
        //string invalidInput = "(defun factorial (n) (if (= n 0 1 (* n (factorial (- n 1)))))";

        bool isValid = ValidateParentheses(validInput);
        Console.WriteLine("Parentheses are properly closed and nested: " + isValid);
    }
}
