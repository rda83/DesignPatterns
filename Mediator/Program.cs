/*
* GOF #17
* Mediator (Посредник - Паттерн поведения объектов.)
* Определяет объект, инкапсулирующий способ взаимодействия множества объектов.
* Посредник обеспечивает слабую связанность системы, избавляя объекты от необходимости
* явно ссылаться друг на друга и позволяя тем самым независимо изменять взаимодействия между ними.
* 25/07/2019
*/

using System;
using System.Collections.Generic;

namespace Mediator
{
    public static class Program
    {
        public static void Main()
        {
            SyncMediator mediator = new SyncMediator();
            Switcher switcher1 = new Switcher(mediator);
            Switcher switcher2 = new Switcher(mediator);
            Switcher switcher3 = new Switcher(mediator);

            switcher1.State = true;
            Console.WriteLine("switcher2: " + switcher2.State);
            Console.WriteLine("switcher3: " + switcher3.State);

            switcher1.Sync();
            Console.WriteLine("switcher2: " + switcher2.State);
            Console.WriteLine("switcher3: " + switcher3.State);

            Console.ReadLine();

        }
    }

    abstract class Mediator
    {
        protected readonly List<Switcher> Switchers =
            new List<Switcher>();

        public abstract void Sync(Switcher switcher);

        public void Add(Switcher switcher)
        {
            Switchers.Add(switcher);
        }
    }

    class Switcher
    {
        public bool State { get; set; }
        readonly Mediator _mediator;

        public Switcher(Mediator mediator)
        {
            this._mediator = mediator;
            mediator.Add(this);
        }

        public void Sync()
        {
            _mediator.Sync(this);
        }
    }

    class SyncMediator : Mediator
    {
        public override void Sync(Switcher switcher)
        {
            bool state = switcher.State;
            foreach (Switcher currentSwitcher in Switchers)
            {
                currentSwitcher.State = state;
            }
        }
    }
}
