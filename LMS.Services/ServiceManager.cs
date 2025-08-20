using Service.Contracts;

namespace LMS.Services;

public class ServiceManager : IServiceManager
{
    private Lazy<IAuthService> authService;
    private readonly Lazy<IModuleService> moduleService;

    public IAuthService AuthService => authService.Value;
    public IModuleService ModuleService => moduleService.Value;


    public ServiceManager(Lazy<IAuthService> authService, Lazy<IModuleService> moduleservice)
    {
        this.authService = authService;
        moduleService = moduleservice;
    }
}
