/*
* GOF #04
* Prototype (Прототип - паттерн, порождающий объекты.)
* Задает виды создаваемых объектов с помощью экземпляра - прототипа
* и создает новые объекты путем копирования этого объекта.
* 06/08/2019
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {

            Square square = new Square("Red");
            ShapeMaker shapeMaker = new ShapeMaker(square);

            Square square2 = (Square) shapeMaker.MakeShape();

            Console.WriteLine(square2.Color);
            Console.ReadLine();
        }
    }

    class ShapeMaker
    {
        private readonly Shape _shape;

        public ShapeMaker(Shape shape)
        {

            this._shape = shape;
        }

        public Shape MakeShape()
        {
            return this._shape.Clone();
        }

    }

    abstract class Shape
    {
        public string Color { get; private set; }

        public Shape(String color)
        {
            this.Color = color;
        }

        public abstract Shape Clone();
    }

    class Square : Shape
    {

        public Square(String color) :
            base(color)
        {
        }

        public override Shape Clone()
        {
            return new Square(this.Color);
        }

    }
}
