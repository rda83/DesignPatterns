/*
 * GOF #01
 * Abstract Factory (Абстрактная фабрика - Паттерн, порождающий объекты.)
 * Предоставляет интерфейс для создания семейств взаимосвязанных или взаимозависимых объектов,
 * не специфицируя их конкретных классов.
 * 11/07/2019
 */

using System;

namespace AbstractFactory
{
    class Program
    {
        public static void Main()
        {
            Client client = null;

            client = new Client(new MotifWidgetFactory());
            client.Run();

            client = new Client(new PMWidgetFactory());
            client.Run();

            Console.ReadLine();

        }
    } 
    public class Client
    {
        private Window window;
        private ScrollBar scrollBar;

        public Client(WidgetFactory widgetFactory)
        {
            window = widgetFactory.CreateWindow();
            scrollBar = widgetFactory.CreateScrollBar();
        }

        public void Run()
        {
            window.Ineract();
            scrollBar.Ineract();
        }
    }

    public abstract class WidgetFactory
    {
        public abstract Window CreateWindow();
        public abstract ScrollBar CreateScrollBar();
    }

    public abstract class Window
    {
        public virtual void Ineract()
        {
            Console.WriteLine(this.GetType());
        }
    }

    public abstract class ScrollBar
    {
        public virtual void Ineract()
        {
            Console.WriteLine(this.GetType());
        }
    }

    public class MotifWidgetFactory : WidgetFactory
    {
        public override Window CreateWindow()
        {
            return new MotifWindow();
        }

        public override ScrollBar CreateScrollBar()
        {
            return new MotifScrollBar();
        }
    }

    public class PMWidgetFactory : WidgetFactory
    {
        public override Window CreateWindow()
        {
            return new PMWindow();
        }

        public override ScrollBar CreateScrollBar()
        {
            return new PMScrollBar();
        }

    }

    public class MotifWindow : Window {}

    public class PMWindow : Window {}

    public class MotifScrollBar : ScrollBar {}

    public class PMScrollBar : ScrollBar {}
    
}
