/*
* GOF #21
* Strategy (Стратегия - паттерн поведения объектов.)
* Определяет семейство алгоритмов, инкапсулирует каждый из них и делает их
* взаимозаменяемыми. Стратегия позволяет изменять алгоритмы независимо от клиентов, которые ими пользуются.
* 28/08/2019
*/

using System;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcreteStrategyA ctrA = new ConcreteStrategyA();
            ConcreteStrategyB ctrB = new ConcreteStrategyB();

            Context ctx1 = new Context(ctrA);
            Context ctx2 = new Context(ctrB);

            ctx1.Execute();
            ctx2.Execute();

            Console.ReadLine();
        }
    }

    class Context
    {
        Strategy strategy;

        public Context(Strategy strategy)
        {
            this.strategy = strategy;
        }

        public void Execute()
        {
            strategy.Operation();
        }
    }

    abstract class Strategy
    {
        public abstract void Operation();
    }

    class ConcreteStrategyA : Strategy
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteStrategyA");
        }
    }

    class ConcreteStrategyB : Strategy
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteStrategyB");
        }
    }
}
