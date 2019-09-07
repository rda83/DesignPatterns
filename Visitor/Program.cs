/*
* GOF #23
* Visitor (Посетитель - Паттерн поведения объектов.)
* Описывает операцию, выполняемую с каждым объектом из некоторой структуры.
* Паттерн посетитель позволяет определить новую операцию, не изменяя классы этих объектов.
* 28/08/2019
*/

using System;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            var car = new Car();
            var v1 = new TestCarVisitor();
            var v2 = new RepairCarVisitor();

            car.Accept(v1);
            car.Accept(v2);

            Console.ReadLine();
        }
    }

    interface IElement
    {
        void Accept(ICarVisitor v);
    }

    class Engine : IElement
    {
        public void Accept(ICarVisitor v)
        {
            v.Visit(this);
        }
    }

    class Wheel : IElement
    {
        readonly int _number;

        public Wheel(int number)
        {
            _number = number;
        }

        public int GetNumber()
        {
            return _number;
        }

        public void Accept(ICarVisitor v)
        {
            v.Visit(this);
        }
    }

    class Car : IElement
    {
        readonly IElement[] _items = {
        new Engine(),
        new Wheel(1), new Wheel(2),
        new Wheel(3), new Wheel(4)};

        public void Accept(ICarVisitor v)
        {
            foreach (var e in _items)
            {
                e.Accept(v);
            }
            v.Visit(this);
        }
    }

    interface ICarVisitor
    {
        void Visit(Engine engine);
        void Visit(Wheel wheel);
        void Visit(Car car);
    }

    class TestCarVisitor : ICarVisitor
    {
        public void Visit(Engine engine)
        {
            Console.WriteLine("test engine");
        }

        public void Visit(Wheel wheel)
        {
            Console.WriteLine("test wheel #" +
            wheel.GetNumber());
        }

        public void Visit(Car car)
        {
            Console.WriteLine("test car");
        }
    }

    class RepairCarVisitor : ICarVisitor
    {
        public void Visit(Engine engine)
        {
            Console.WriteLine("repair engine");
        }

        public void Visit(Wheel wheel)
        {
            Console.WriteLine("repair wheel #" +
            wheel.GetNumber());
        }

        public void Visit(Car car)
        {
            Console.WriteLine("repair car");
        }
    }
}
