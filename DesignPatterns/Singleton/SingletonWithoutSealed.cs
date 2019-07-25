using System;

namespace DesignPatterns.Singleton
{
    class SingletonWithoutSealed
    {
        private static int counter = 0;
        private static SingletonWithoutSealed instance = null;
        public static SingletonWithoutSealed GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new SingletonWithoutSealed();
                return instance;
            }
        }
        private SingletonWithoutSealed()
        {
            counter++;
            Console.WriteLine("Counter Value " + counter.ToString());
        }
        public void PrintDetails(string message)
        {
            Console.WriteLine(message);
        }

        public class DerivedSingleton : SingletonWithoutSealed
        {

        }


        static void Main1(string[] args)
        {
            SingletonWithoutSealed fromTeachaer = SingletonWithoutSealed.GetInstance;
            fromTeachaer.PrintDetails("From Teacher");

            SingletonWithoutSealed fromStudent = SingletonWithoutSealed.GetInstance;
            fromStudent.PrintDetails("From Student");

            /*
             * Instantiating singleton from a derived class will initialize the private constructor again.
             * This violates singleton pattern principles.
             */
            DerivedSingleton derivedObj = new DerivedSingleton();
            derivedObj.PrintDetails("From Derived");

            SingletonWithoutSealed derivedParentChild = new DerivedSingleton();
            derivedParentChild.PrintDetails("From Derived Parent Child");

            Console.ReadLine();
        }
    }
}