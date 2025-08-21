using Service.Contracts;

namespace LMS.Services;

public class ServiceManager : IServiceManager
{
    private Lazy<IAuthService> authService;
    public IAuthService AuthService => authService.Value;

    // Module service
    private readonly Lazy<IModuleService> moduleService;
    public IModuleService ModuleService => moduleService.Value;


    public ServiceManager(
        Lazy<IAuthService> authService, 
        Lazy<IModuleService> moduleservice
        )
    {
        this.authService = authService;
        this.moduleService = moduleservice;
    }
}
