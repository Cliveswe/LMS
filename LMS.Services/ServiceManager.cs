//Ignore Spelling: auth
using Service.Contracts;

namespace LMS.Services;

public class ServiceManager : IServiceManager
{
    private Lazy<IAuthService> authService;
    public IAuthService AuthService => authService.Value;

    //Course Service
    private Lazy<ICourseService> courseService;
    public ICourseService CourseService => courseService.Value;

    public ServiceManager(
        Lazy<IAuthService> authService,
        Lazy<ICourseService> courseService
        )
    {
        this.authService = authService;
        this.courseService = courseService;
    }
}
