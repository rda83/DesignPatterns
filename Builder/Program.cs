/*
* GOF #02
* Builder (Строитель - паттерн, порождающий объекты.)
* Отделяет конструирование сложного объекта от его представления,
* так что в результате одного и того же процесса конструирования
* могут получаться разные представления.
* 17/07/2019
*/

using System;
using System.Collections;

namespace Builder
{
    public static class Program
    {
        public static void Main()
        {
            Builder builder = new ConcreteBuilder();
            Director director = new Director(builder);
            director.Construct();
            Product product = builder.GetResult();
            product.Show();

            Console.ReadLine();

        }
    }

    public class Product
    {
        ArrayList parts = new ArrayList();

        public void Add(string part)
        {
            parts.Add(part);
        }

        public void Show()
        {
            foreach (string part in parts)
            {
                Console.WriteLine(part);
            }
        }

    }

    public abstract class Builder
    {
        public abstract void BuildPartA();
        public abstract void BuildPartB();
        public abstract void BuildPartC();
        public abstract Product GetResult();
    }

    public class ConcreteBuilder: Builder
    {

        Product product = new Product();
   
        public override void BuildPartA()
        {
            product.Add("Part A.");
        }

        public override void BuildPartB()
        {
            product.Add("Part B.");
        }

        public override void BuildPartC()
        {
            product.Add("Part C.");
        }

        public override Product GetResult()
        {
            return product;
        }
    }

    public class Director
    {
        Builder builder;

        public Director(Builder builder)
        {
            this.builder = builder;
        }

        public void Construct()
        {
            builder.BuildPartA();
            builder.BuildPartB();
            builder.BuildPartC();
        }
    }
}
