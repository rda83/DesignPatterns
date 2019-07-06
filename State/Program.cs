/*
 * GOF #20
 * State (Состояние - паттерн поведения объектов.)
 * Позволяет объекту варьировать свое поведение в зависимости от внутреннего состояния. 
 * Извне создается впечатление, что изменился класс объекта.
 * 06/07/2019
 */

using System;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            context.Request();
            context.Request();
            Console.ReadLine();
        }
    }

    public class Context
    {
        State _state;

        public Context()
        {
            this._state = new State_0();
        }

        public void Request()
        {
            _state.Handle(this);
        }

        internal void ChangeState(State state)
        {
            this._state = state;
        }
    }

    public abstract class State
    {
        public abstract void Handle(Context context);

        protected virtual void ChangeState(Context context, State state)
        {
            context.ChangeState(state);
        }
    }

    public class State_0 : State
    {
        public override void Handle(Context context)
        {
            Console.WriteLine("State_0 - > State_1");
            ChangeState(context, new State_1());
        }
    }

    public class State_1 : State
    {
        public override void Handle(Context context)
        {
            Console.WriteLine("State_1 - > State_0");
            ChangeState(context, new State_0());
        }
    }
}
    