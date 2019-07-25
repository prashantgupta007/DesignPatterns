namespace DesignPatterns.Singleton
{
    public class SingletonEagerInitialization
    {

        private static readonly SingletonEagerInitialization instance = new SingletonEagerInitialization();
        private SingletonEagerInitialization() { }

        public static SingletonEagerInitialization GetInstance
        {
            get
            {
                return instance;
            }
        }
    }
}
