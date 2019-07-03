/*
 * GOF #15
 * Interpreter (Инетпретатор - патерн поведения классов.)
 * Для заданного языка определяет представление его грамматики, а так же интерпретатор предложений этого языка.
 * 03/07/2019
 */

using System;

namespace Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Context().Evaluate("3+2-1").Interpret());
            Console.ReadLine();
        }
    }

    interface Expression
    {
        int Interpret();
    }

    class NumberExpression : Expression
    {
        int number;

        public NumberExpression(int number)
        {
            this.number = number;
        }

        public int Interpret()
        {
            return number;
        }
    }

    class MinusExpression : Expression
    {
        Expression left;
        Expression right;

        public MinusExpression(Expression left, Expression right)
        {
            this.left = left;
            this.right = right;
        }

        public int Interpret()
        {
            return left.Interpret() - right.Interpret();
        }
    }

    class PlusExpression : Expression
    {
        Expression left;
        Expression right;

        public PlusExpression(Expression left, Expression right)
        {
            this.left = left;
            this.right = right;
        }

        public int Interpret()
        {
            return left.Interpret() + right.Interpret();
        }
    }

    class Context
    {
        public Expression Evaluate(String s)
        {
            int pos = s.Length - 1;
            while (pos > 0)
            {
                //Expression left = null;
                if (Char.IsDigit(s[pos]))
                {
                    pos--;
                }
                else
                {
                    Expression left = Evaluate(s.Substring(0, pos));
                    int number = int.Parse(s.Substring(pos + 1));
                    Expression right = new NumberExpression(number);

                    Char oprt = s[pos];
                    switch (oprt.ToString())
                    {
                        case "-": return new MinusExpression(left, right);
                        case "+": return new PlusExpression(left, right);
                    }
                }
            }
            int result = int.Parse(s);
            return new NumberExpression(result);
        }
    }
}


