/*
* GOF #09
* Decorator (Декоратор - паттерн, структурирующий объекты.)
* Динамически добавляет объекту новые обязанности. 
* Является гибкой альтернативой порождению подклассов с целью расширения функциональности.
* 31/07/2019
*/

using System;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            MessagingSystem MS = new MessagingSystem("Text message");
            CompressionHandler CH = new CompressionHandler(MS);
            EncryptionHandler ET = new EncryptionHandler(CH);
            ElectronicSignatureProcessor ESP = new ElectronicSignatureProcessor(ET);
            ESP.Run();

            Console.ReadLine();

        }
    }

    public interface IMessagingSystem
    {
        void Run();
    }

    public class MessagingSystem : IMessagingSystem
    {
        public string TextMessage { set; get; }

        public MessagingSystem(string textMessage)
        {
            TextMessage = textMessage;
        }

        public void Run()
        {
            Console.WriteLine("Send message: " + TextMessage);
        }
    }

    public abstract class AdditionalHandler : IMessagingSystem
    {
        protected IMessagingSystem messagingSystem;

        public abstract void Run();
    }

    public class EncryptionHandler : AdditionalHandler
    {
        public EncryptionHandler(IMessagingSystem messagingSystem)
        {
            this.messagingSystem = messagingSystem;
        }

        override public void Run()
        {
            Console.WriteLine("Encrypted message");
            this.messagingSystem.Run();
        }
    }

    public class CompressionHandler : AdditionalHandler
    {
        public CompressionHandler(IMessagingSystem messagingSystem)
        {
            this.messagingSystem = messagingSystem;
        }

        override public void Run()
        {
            Console.WriteLine("Compressed text");
            this.messagingSystem.Run();
        }
    }

    public class ElectronicSignatureProcessor : AdditionalHandler
    {
        public ElectronicSignatureProcessor(IMessagingSystem messagingSystem)
        {
            this.messagingSystem = messagingSystem;
        }

        override public void Run()
        {
            Console.WriteLine("Signed text");
            this.messagingSystem.Run();
        }
    }

}
