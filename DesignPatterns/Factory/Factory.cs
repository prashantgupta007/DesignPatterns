using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Factory
{
    interface IProduct
    {

    }

    class ConcreteProductA : IProduct
    {
    }

    class ConcreteProductB : IProduct
    {
    }

    abstract class Creator
    {
        public abstract IProduct FactoryMethod(string type);
    }

    class ConcreteCreator : Creator
    {
        public override IProduct FactoryMethod(string type)
        {
            switch (type)
            {
                case "A":
                    return new ConcreteProductA();
                case "B":
                    return new ConcreteProductB();
                default:
                    throw new ArgumentException("Invalid type: ", type);
            }
        }
    }
}