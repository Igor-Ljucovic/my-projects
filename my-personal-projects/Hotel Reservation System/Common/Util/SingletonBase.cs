namespace Common.Util
{
    public abstract class SingletonBase<T> where T : class, new()
    {
        private static readonly object lockObject = new object();
        private static T instance;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new T();
                        }
                    }
                }
                return instance;
            }
        }

        protected SingletonBase() { }
    }
}
