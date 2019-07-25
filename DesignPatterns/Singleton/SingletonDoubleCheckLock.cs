namespace DesignPatterns.Singleton
{
    public class SingletonDoubleCheckLock
    {
        private static SingletonDoubleCheckLock instance = null;
        private static readonly object padlock = new object();

        private SingletonDoubleCheckLock() { }

        public static SingletonDoubleCheckLock Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new SingletonDoubleCheckLock();
                        }
                    }
                }
                return instance;
            }
        }
    }
}
