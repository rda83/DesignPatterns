/*
* GOF #16
* Iterator (Итератор - паттерн поведения объектов.)
* Предоставляет способ последовательного доступа ко всем элементам составного объекта,
* не раскрывая его внутреннего представления.
* 17/07/2019
*/

using System;

namespace Iterator
{
    public static class Program
    {
        public static void Main()
        {
            var numbers = new PrimeNumbers();
            var iterator = numbers.GetIterator();
            int sum = 0;
            for (iterator.First(); !iterator.IsDone(); iterator.Next())
            {
                sum += iterator.CurrentItem();
            }

            Console.WriteLine(sum);
            Console.ReadLine();
        }
    }

    interface IIntIterator
    {
        void First();
        void Next();
        bool IsDone();
        int CurrentItem();
    }

    interface IIntAggregate
    {
        IIntIterator GetIterator();
    }

    class PrimeNumbers : IIntAggregate
    {
        readonly int[] _numbers = { 2, 3, 5, 7, 11 };

        public IIntIterator GetIterator()
        {
            return new Iterator(this);
        }

        class Iterator : IIntIterator
        {
            int _index;
            readonly PrimeNumbers _parrent;

            public Iterator(PrimeNumbers parrent)
            {
                _parrent = parrent;
            }

            public void First()
            {
                _index = 0;
            }

            public void Next()
            {
                _index++;
            }

            public bool IsDone()
            {
                return _index >= _parrent._numbers.Length;
            }

            public int CurrentItem()
            {
                return _parrent._numbers[_index];
            }
        }
    }
}
