/*
 * GOF #03
 * Factory method (Фабричный метод - паттерн, порождающий классы.)
 * Определяет интерфейс для создания объекта, но оставляет подклассам решение о том, какой класс инстанцировать.
 * Фабричный метод позволяет классу делегировать инстанцирование подклассам.
 * 27/07/2019
 */

using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            IFactoryMesseger factoryMesseger;

            factoryMesseger = FactoryMessegerMaker(TypeMessger.WhatsApp);
            factoryMesseger.GetMessger().Send("Text message");

            factoryMesseger = FactoryMessegerMaker(TypeMessger.Viber);
            factoryMesseger.GetMessger().Send("Text message");

            factoryMesseger = FactoryMessegerMaker(TypeMessger.Telegramm);
            factoryMesseger.GetMessger().Send("Text message");

            Console.ReadLine();

        }

        static IFactoryMesseger FactoryMessegerMaker(TypeMessger typeMessger)
        {
            IFactoryMesseger result = null;

            if(typeMessger == TypeMessger.WhatsApp)
            {

                result = new WhatsAppFactoryMesseger();
            }else if(typeMessger == TypeMessger.Viber)
            {

                result = new ViberFactoryMesseger();
            }else if(typeMessger == TypeMessger.Telegramm)
            {

                result = new TelegrammFactoryMesseger();
            }

            return result;
        }
    }

    public abstract class IMessger
    {
        public void Send(string message)
        {
            string data = String.Format("Type messeger: {0} -> Send message -> {1}", this.GetType(), message);
            Console.WriteLine(data);
        }
    }

    public interface IFactoryMesseger
    {
        IMessger GetMessger();
            
    }

    public class WhatsAppMesseger : IMessger { }

    public class ViberMesseger : IMessger { }

    public class TelegrammMesseger : IMessger { }

    public class WhatsAppFactoryMesseger : IFactoryMesseger
    {
        public IMessger GetMessger()
        {
            return new WhatsAppMesseger();
        }
    }

    public class ViberFactoryMesseger : IFactoryMesseger
    {
        public IMessger GetMessger()
        {
            return new ViberMesseger();
        }
    }

    public class TelegrammFactoryMesseger : IFactoryMesseger
    {
        public IMessger GetMessger()
        {
            return new TelegrammMesseger();
        }
    }

    public enum TypeMessger
    {
        WhatsApp,
        Viber,
        Telegramm
    }

}
