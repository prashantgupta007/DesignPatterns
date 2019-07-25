using System;

namespace DesignPatterns.Singleton
{
    sealed class SingletonWithSealed
    {
        private static int counter = 0;
        private static SingletonWithSealed instance = null;
        public static SingletonWithSealed GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new SingletonWithSealed();
                return instance;
            }
        }
        private SingletonWithSealed()
        {
            counter++;
            Console.WriteLine("Counter Value " + counter.ToString());
        }

        public void PrintDetails(string message)
        {
            Console.WriteLine(message);
        }

        //It'll give compilation error
        //public class DerivedSingleton : SingletonWithSealed
        //{

        //}
        //'SingletonWithSealed.DerivedSingleton': cannot derive from sealed type 'SingletonWithSealed'


        static void Main(string[] args)
        {
            SingletonWithSealed fromTeachaer = SingletonWithSealed.GetInstance;
            fromTeachaer.PrintDetails("From Teacher");

            SingletonWithSealed fromStudent = SingletonWithSealed.GetInstance;
            fromStudent.PrintDetails("From Student");

            Console.ReadLine();
        }
    }
}