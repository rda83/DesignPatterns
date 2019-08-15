/*
 * GOF #11
 * Flyweight (Приспособленец - паттерн, структурирующий объекты.)
 * Использует разделение для эффективной поддержки множества мелких объектов.
 * 15/08/2019
 */

using System;
using System.Collections.Generic;

namespace Flyweight
{
    class Program
    {
        static void Main(string[] args)
        {
            ShapeFactory.GetShape(ShapeType.Circle).Draw(5, 10);
            ShapeFactory.GetShape(ShapeType.Circle).Draw(10, 5);
            ShapeFactory.GetShape(ShapeType.Square).Draw(15, 1);
            ShapeFactory.GetShape(ShapeType.Square).Draw(1, 15);
            ShapeFactory.GetShape(ShapeType.Point).Draw(4, 6);
            ShapeFactory.GetShape(ShapeType.Point).Draw(6, 4);

            Console.ReadLine();
        }
    }

    enum ShapeType
    {
        Circle,
        Square,
        Point
    }

    static class ShapeFactory
    {
        private static Dictionary<ShapeType, Shape> shapes = new Dictionary<ShapeType, Shape>();

        public static Shape GetShape(ShapeType shapeType)
        {
            Shape result = null;

            if (!shapes.ContainsKey(shapeType))
            {
                switch (shapeType)
                {
                    case ShapeType.Circle:
                        result = new Circle();
                        shapes.Add(shapeType, result);
                        break;

                    case ShapeType.Square:
                        result = new Square();
                        shapes.Add(shapeType, result);
                        break;

                    case ShapeType.Point:
                        result = new Point();
                        shapes.Add(shapeType, result);
                        break;
                }            
            }
            else
            {
                result = shapes[shapeType];
            }
            return result;
        }
    }

    interface Shape
    {
        void Draw(int x, int y);
    }

    class Circle : Shape
    {
        const int radius = 5;
        public void Draw(int x, int y)
        {
            Console.WriteLine($"Circle drow: x = {x}; y = {y}. Radius = {radius}");
        }
    }

    class Square : Shape
    {
        const int sideSize = 5;
        public void Draw(int x, int y)
        {
            Console.WriteLine($"Square drow: x = {x}; y = {y}. Side size = {sideSize}");
        }
    }

    class Point : Shape
    {
        public void Draw(int x, int y)
        {
            Console.WriteLine($"Point drow: x = {x}; y = {y}");
        }
    }
}