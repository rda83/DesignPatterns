/*
 * GOF #14
 * Command (Команда - паттерн поведения объектов.)
 * Инкапсулирует запрос как объект, позволяя тем самым задавать параметры клиентов для обработки соответствующих запросов,
 * ставить запросы в очередь или протоколировать их, а также поддерживать отмену операции.
 * 14/08/2019
 */

using System;
using System.Collections.Generic;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();
            int result = 0;

            result = calculator.Add(5);
            Console.WriteLine(result);

            result = calculator.Sub(3);
            Console.WriteLine(result);
            
            result = calculator.Undo(2);
            Console.WriteLine(result);
           
            result = calculator.Redo(2);
            Console.WriteLine(result);
            
            Console.ReadLine();
        }
    }

    class Calculator
    {
        ArithmeticUnit arithmeticUnit;
        ControlUnit controlUnit;

        public Calculator()
        {
            this.arithmeticUnit = new ArithmeticUnit();
            this.controlUnit = new ControlUnit();
        }

        private int Run(Command command)
        {
            controlUnit.StoreCommand(command);
            controlUnit.ExecuteCommand();
            return arithmeticUnit.Register;
        }

        public int Add(int operand)
        {
            return Run(new Add(arithmeticUnit, operand));
        }

        public int Div(int operand)
        {
            return Run(new Div(arithmeticUnit, operand));
        }

        public int Mul(int operand)
        {
            return Run(new Mul(arithmeticUnit, operand));
        }

        public int Sub(int operand)
        {
            return Run(new Sub(arithmeticUnit, operand));
        }

        public int Redo(int levels)
        {
            controlUnit.Redo(levels);
            return arithmeticUnit.Register;
        }

        public int Undo(int levels)
        {
            controlUnit.Undo(levels);
            return arithmeticUnit.Register;
        }
    }

    class ControlUnit
    {
        List<Command> commands = new List<Command>();
        int current = 0;

        public void ExecuteCommand()
        {
            commands[current].Execute();
            current++;
        }

        public void Undo(int levels)
        {
            for(int i = 0; i < levels; i++)
            {
                if(current > 0)
                {
                    commands[--current].UnExecute();
                }
            }
        }

        public void Redo(int levels)
        {
            for (int i = 0; i < levels; i++)
            {
                if (current < commands.Count - 1)
                {
                    commands[current++].Execute();
                }
            }
        }

        public void StoreCommand(Command command)
        {
            commands.Add(command);
        }
    }

    abstract class Command
    {
        protected int operand;
        protected ArithmeticUnit arithmeticUnit;

        public abstract void Execute();
        public abstract void UnExecute();
    }

    class Add : Command
    {
        public Add(ArithmeticUnit arithmeticUnit, int operand)
        {
            this.arithmeticUnit = arithmeticUnit;
            this.operand = operand;
        }

        public override void Execute()
        {
            arithmeticUnit.Run('+', operand);
        }

        public override void UnExecute()
        {
            arithmeticUnit.Run('-', operand);
        }
    }

    class Sub : Command
    {
        public Sub(ArithmeticUnit arithmeticUnit, int operand)
        {
            this.arithmeticUnit = arithmeticUnit;
            this.operand = operand;
        }

        public override void Execute()
        {
            arithmeticUnit.Run('-', operand);
        }

        public override void UnExecute()
        {
            arithmeticUnit.Run('+', operand);
        }
    }

    class Mul : Command
    {
        public Mul(ArithmeticUnit arithmeticUnit, int operand)
        {
            this.arithmeticUnit = arithmeticUnit;
            this.operand = operand;
        }

        public override void Execute()
        {
            arithmeticUnit.Run('*', operand);
        }

        public override void UnExecute()
        {
            arithmeticUnit.Run('/', operand);
        }
    }

    class Div : Command
    {
        public Div(ArithmeticUnit arithmeticUnit, int operand)
        {
            this.arithmeticUnit = arithmeticUnit;
            this.operand = operand;
        }

        public override void Execute()
        {
            arithmeticUnit.Run('/', operand);
        }

        public override void UnExecute()
        {
            arithmeticUnit.Run('*', operand);
        }
    }

    class ArithmeticUnit
    {
        public int Register { get; set; }

        public void Run (char operationCode, int operand)
        {
            switch(operationCode)
            {
                case '+':
                    Register += operand;
                    break;

                case '-':
                    Register -= operand;
                    break;

                case '*':
                    Register *= operand;
                    break;

                case '/':
                    Register /= operand;
                    break;
            }
        }
    }
}
