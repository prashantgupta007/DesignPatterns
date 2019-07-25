using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Singleton
{
    public class SingletonLazyInitialization
    {
        private static SingletonLazyInitialization instance = null;
        private SingletonLazyInitialization() { }

        public static SingletonLazyInitialization GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new SingletonLazyInitialization();

                return instance;
            }
        }
    }

}
