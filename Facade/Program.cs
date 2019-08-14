/*
 * GOF #10
 * Facade (Фасад - паттерн, структурирующий объекты.)
 * Предоставляет унифицированный интерфейс вместо набора интерфейсов ненкоторой подсистемы.
 * Фасад определяет интерфейс более высокого уровня, который упрощает использование подсистемы.
 * 14/08/2019
 */

using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            Facade facade = new Facade();
            facade.OperationAB();
            facade.OperationBC();

            Console.ReadLine();
        }
    }

    class Facade
    {
        SubSystemA subSystemA = new SubSystemA();
        SubSystemB subSystemB = new SubSystemB();
        SubSystemC subSystemC = new SubSystemC();

        public void OperationAB()
        {
            subSystemA.OperationA();
            subSystemB.OperationB();
        }

        public void OperationBC()
        {
            subSystemB.OperationB();
            subSystemC.OperationC();
        }
    }

    class SubSystemA
    {
        public void OperationA()
        {
            Console.WriteLine("OperationA");
        }
    }

    class SubSystemB
    {
        public void OperationB()
        {
            Console.WriteLine("OperationB");
        }
    }

    class SubSystemC
    {
        public void OperationC()
        {
            Console.WriteLine("OperationC");
        }
    }
}
