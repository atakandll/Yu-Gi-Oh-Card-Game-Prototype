namespace Patterns.Singleton
{
    public class Singleton<T> where T : class, new()
    {
        //a protected constructor
        protected Singleton()
        {
        }

        //public getter
        public static T Instance { get; private set; } = CreateInstance();

        private static T CreateInstance()
        {
            return Instance ?? (Instance = new T());
        }

        //Setter used to inject an instance 
        public void InjectInstance(T instance)
        {
            if (instance != null)
                Instance = instance;
        }
    }
}