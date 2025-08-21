namespace Service.Contracts;
public interface IServiceManager
{
    IAuthService AuthService { get; }
    public IUserService UserService { get; }
}