namespace Library.Net.Cache
{
    public interface ICacheProvider
    {
        object Get(string key);
        void Set(string key, object data, int cacheTimeInMinutes);
        bool IsSet(string key);
        void Invalidate(string key);
    }
}
