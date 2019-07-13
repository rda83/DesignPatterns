/*
 * GOF #06
 * Adapter (Адаптер - паттерн, структурирующий классы и объекты.)
 * Преобразует интерфейс одного класса в интерфейс другого, который ожидают клиенты.
 * Адаптер обеспечивает совместную работу классов с несовместимыми интерфейсами, которая без него была бы невозможна.
 * 13/07/2019
 */

using System;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client_1 = new Client(new Target());
            client_1.Do();

            Client client_2 = new Client(new Adapter_via_inheritance());
            client_2.Do();

            Client client_3 = new Client(new Adapter_via_composition());
            client_3.Do();

            Console.ReadLine();

        }
    }

    public class Client
    {
        ITarget target;

        public Client(ITarget target)
        {
            this.target = target;
        }

        public void Do()
        {
            target.Request();
        }

    }

    public interface ITarget
    {
        void Request();
    }

    public class Target : ITarget
    {
        public void Request()
        {
            Console.WriteLine("Request.");
        }
    }

    public class Adapter_via_inheritance : Adaptee, ITarget
    {
        public void Request()
        {
            base.SpecificRequest();
        }
    }

    public class Adapter_via_composition: ITarget
    {
        private Adaptee adaptee = new Adaptee();
        public void Request()
        {
            adaptee.SpecificRequest();
        }
    }

    public class Adaptee
    {
        public void SpecificRequest()
        {
            Console.WriteLine("Specific request.");
        }
    }
}
