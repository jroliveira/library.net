namespace Library.Net.Mvc.Authentication
{
    public interface ICurrentAuthenticatedUser<T>
        where T : IAuthenticatedUser
    {
        T Get();
        void Create(T authenticatedUser);
    }
}