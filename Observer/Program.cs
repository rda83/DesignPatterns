/*
 * GOF #19
 * Observer (Наблюдатель - Паттерн поведения объектов.)
 * Определяет зависимость типа "один ко многим" между объектами таким образом, что при изменении состояния одного объекта
 * все зависящие от него оповещаются об этом и автоматически обновляются.
 * 07/09/2019
 */

using System;
using System.Collections.Generic;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            var observer1 = new TextObserver("IObserver #1");
            var observer2 = new TextObserver("IObserver #2");

            TextEdit textEdit = new TextEdit();
            textEdit.Attach(observer1);
            textEdit.Attach(observer2);

            textEdit.SetText("test text");

            Console.ReadLine();
        }
    }

    interface IObserver
    {
        void Update(String state);
    }

    class TextObserver : IObserver
    {
        readonly String _name;

        public TextObserver(String name)
        {
            _name = name;
        }

        public void Update(String state)
        {
            Console.WriteLine(_name + ": " + state);
        }
    }

    abstract class TestSubject
    {
        readonly List<IObserver> _observers =
        new List<IObserver>();

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        protected void Notify(String state)
        {
            foreach (var observer in _observers)
            {
                observer.Update(state);
            }
        }
    }

    class TextEdit : TestSubject
    {
        string _text = "";

        public void SetText(String text)
        {
            _text = text;
            Notify(text);
        }

        public String GetText()
        {
            return _text;
        }
    }
}
