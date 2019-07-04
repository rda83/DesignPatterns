
/*
 * GOF #08
 * Composite (Компоновщик - паттерн, структурирующий объекты.)
 * Компонует объекты в древовидные структуры для иерархий часть-целое. 
 * Позволяет клиентам единообразно трактовать индивидуальные и составные объекты.
 * 04/07/2019
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Component branch_00 = new Composite("root");
            Component branch_01 = new Composite("branch_02");
            Component branch_02 = new Composite("branch_03");
            Component node_00   = new Leaf("node_00");
            Component node_01   = new Leaf("node_00");

            branch_00.Add(branch_01);
            branch_00.Add(branch_02);
            branch_01.Add(node_00);
            branch_02.Add(node_01);

            branch_00.Operation();
            Console.ReadLine();
        }
    }

    public abstract class Component
    {  
        protected string name;
        public Component(string name)
        {
            this.name = name;
        }

        public abstract void Operation();
        public abstract void Add(Component component);
        public abstract void Remove(Component component);
        public abstract Component GetChild(int index);   
    }

    public class Leaf: Component
    {
        public Leaf(string name): base(name) { }

        public override void Operation()
        {
            Console.WriteLine(name);
        }

        public override void Add(Component component)
        {
            throw new InvalidOperationException();
        }

        public override void Remove(Component component)
        {
            throw new InvalidOperationException();
        }

        public override Component GetChild(int index)
        {
            throw new InvalidOperationException();
        }
    }

    public class Composite: Component
    {
        ArrayList nodes = new ArrayList();

        public Composite(string name): base(name) { }

        public override void Operation()
        {
            Console.WriteLine(name);

            foreach (Component component in nodes)
            {
                component.Operation();
            }

        }

        public override void Add(Component component)
        {
            nodes.Add(component);
        }

        public override void Remove(Component component)
        {
            nodes.Remove(component);
        }

        public override Component GetChild(int index)
        {
            return nodes[index] as Component;
        }
    }
}
