using Service.Contracts;

namespace LMS.Services;

public class ServiceManager : IServiceManager
{
    private Lazy<IAuthService> authService;
    public IAuthService AuthService => authService.Value;
    public IModuleActivityService ModuleActivityService { get; }

    public ServiceManager(Lazy<IAuthService> authService, IModuleActivityService moduleActivityService)
    {
        this.authService = authService;
        this.ModuleActivityService = moduleActivityService;
    }
}
