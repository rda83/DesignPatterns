/*
* GOF #22
* Template Method (Шаблонный метод - паттерн поведения объектов.)
* Шаблонный метод определяет основу алгоритма и позволяет подклассам
* переопределить некоторые шаги алгоритма, не изменяя его структуры в целом.
* 28/08/2019
*/

using System;

namespace TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            var сircle = new Сircle();
            сircle.Draw();

            Console.ReadLine();
        }
    }

    abstract class Shape
    {
        public void Draw()
        {
            if (!canDraw())
                return;
            DoDraw();
            notifyListeners();
        }

        bool canDraw()
        {
            return true;
        }

        protected abstract void DoDraw();

        void notifyListeners()
        {
            Console.WriteLine("shape is drawn");
        }
    }

    class Сircle : Shape
    {
        protected override void DoDraw()
        {
            Console.WriteLine("draw a circle");
        }
    }
}
