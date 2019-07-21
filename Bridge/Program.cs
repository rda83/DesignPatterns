/*
* GOF #07
* Bridge (Мост - паттерн, структурирующий объекты.)
* Отделяет абстракцию от ее реализации так, чтобы то и другое можно было изменять независимо.
* 21/07/2019
*/

using System;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            string text_message = "Text message";

            new WhatsApp(new HTTP_ConnectionType()).Send(text_message);
            new WhatsApp(new HTTPS_ConnectionType()).Send(text_message);
            Console.WriteLine("");

            new Viber(new HTTP_ConnectionType()).Send(text_message);
            new Viber(new HTTPS_ConnectionType()).Send(text_message);
            Console.WriteLine("");

            new Telegram(new HTTP_ConnectionType()).Send(text_message);
            new Telegram(new HTTPS_ConnectionType()).Send(text_message);

            Console.ReadLine();
        }
    }

    public abstract class Messeger
    {
        protected ConnectionType connectionType;

        public Messeger(ConnectionType connectionType)
        {
           this.connectionType = connectionType;
        }

        public abstract void Send(string messsage);
    }

    public class WhatsApp : Messeger
    {
        public WhatsApp(ConnectionType connectionType) : base(connectionType) { }
       
        public override void Send(string message)
        {
            Console.Write("WhatsApp messeger: ");
            Console.WriteLine(connectionType.GetConnection() + " -> " +message);
        }
    }

    public class Viber : Messeger
    {
        public Viber(ConnectionType connectionType) : base(connectionType) { }

        public override void Send(string message)
        {
            Console.Write("Viber messeger: ");
            Console.WriteLine(connectionType.GetConnection() + " -> " + message);
        }
    }

    public class Telegram : Messeger
    {
        public Telegram(ConnectionType connectionType) : base(connectionType) { }

        public override void Send(string message)
        {
            Console.Write("Telegram messeger: ");
            Console.WriteLine(connectionType.GetConnection() + " -> " + message);
        }
    }

    public abstract class ConnectionType
    {
        public abstract string GetConnection();
    }

    public class HTTP_ConnectionType : ConnectionType
    {
        public override string GetConnection()
        {
            return "HTTP";
        }
    }

    public class HTTPS_ConnectionType : ConnectionType
    {
        public override string GetConnection()
        {
            return "HTTPS";
        }
    }
}
