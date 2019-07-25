namespace DesignPatterns.Singleton
{
    public class SingletonThreadSafe
    {
        private static SingletonThreadSafe _instance;
        private static readonly object padLock = new object();

        private SingletonThreadSafe(){ }

        public static SingletonThreadSafe Instance
        {
            get
            {
                lock (padLock)
                {
                    if (_instance == null)
                        _instance = new SingletonThreadSafe();
                    return _instance;
                }
            }
        }
    }
}