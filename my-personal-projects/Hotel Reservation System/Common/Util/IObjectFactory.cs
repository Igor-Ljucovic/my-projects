namespace Common.Util
{
    public interface IObjectFactory<T> where T : new()
    {
        static abstract T CreateInstance();
    }
}
