/*
 * GOF #05
 * Singleton (Синглтон - паттерн, порождающий объекты.)
 * Гарантирует, что у класса есть только один экземпляр,
 * и предоставляет к нему глобальную точку доступа.
 * 14/08/2019
 */

using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton instance1 = Singleton.Instance();
            Singleton instance2 = Singleton.Instance();

            Console.WriteLine(ReferenceEquals(instance1, instance2));

            instance2.SingltoneData = "singleton data";
            Console.WriteLine(instance1.SingltoneData);

            Console.ReadLine();
        }
    }

    class Singleton
    {
        static Singleton uniqueInstance;
        public string SingltoneData { get; set; }

        public static Singleton Instance()
        {
            if(uniqueInstance == null)
            {
                uniqueInstance = new Singleton();
            }

            return uniqueInstance;
        }
    }
}
