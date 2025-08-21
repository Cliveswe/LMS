using Service.Contracts;

namespace LMS.Services;

public class ServiceManager(Lazy<IAuthService> authService,
    Lazy<IUserService> userService) : IServiceManager
{
    private readonly Lazy<IAuthService> authService = authService;
    private readonly Lazy<IUserService> userService = userService;
    public IAuthService AuthService => authService.Value;
    public IUserService UserService => userService.Value;
}
