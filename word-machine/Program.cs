using System;
using System.Collections.Generic;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

var solution = new Solution();

Console.WriteLine(solution.solution("4 5 6 - 7 +"));
Console.WriteLine(solution.solution("13 DUP 4 POP 5 DUP + -"));
Console.WriteLine(solution.solution("5 6 + -"));
Console.WriteLine(solution.solution("3 DUP 5 - -"));


class Solution {
    private const string DUP = "DUP";
    private const string POP = "POP";
    private const string PLUS = "+";
    private const string MINUS = "-";
    private const int LIMIT = 1048575;
    
    public int solution(string S) {
        var result = -1;
        try {
            var numberStack = new Stack<int>();
            var commands = S.Split(" ");

            foreach(var command in commands) {
                if(!int.TryParse(command, out int number))
                {   
                    switch(command) {
                        case POP:
                            numberStack.Pop();
                            break;
                        case DUP:
                            duplicate(ref numberStack);
                            break;
                        case PLUS:
                            operate(ref numberStack, PLUS);
                            break;
                        case MINUS:
                            operate(ref numberStack, MINUS);
                            break;
                        default:
                            throw new InvalidCastException("Invalid character found.");
                    }
                }
                else {
                    if(number >= LIMIT) {
                        throw new OverflowException("Number is too large.");
                    }
                    numberStack.Push(number);
                }
            }

            result = numberStack.Pop();
        }
        catch (Exception)
        {
            return -1;
        }

        return result;
    }

    public static void duplicate(ref Stack<int> stack)
    {
        var number = stack.Pop();
        stack.Push(number);
        stack.Push(number);
    }

    public static void operate(ref Stack<int> stack, string ops)
    {
        var number2 = stack.Pop();
        var number = stack.Pop();
        if (ops == MINUS) {
            var operationResult = number2 - number;

            if(operationResult < 0 && stack.Count == 0){
                throw new ArithmeticException("Result cant be negative");
            }

            var result = (int)Math.Abs(operationResult);
            
            if(result >= LIMIT) {
                throw new OverflowException("Number is too large.");
            }

            stack.Push(result);
        }
        else if (ops == PLUS) {
            var operationResult = number + number2;

            if(operationResult >= LIMIT) {
                throw new OverflowException("Number is too large.");
            }
            
            stack.Push(operationResult);
        } else {
            throw new ArgumentException("Invalid operation");
        }
    }

}

