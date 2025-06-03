using Faculty_Student.Application.Users.ServiceContracts;
using Faculty_Student.Application.Users.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Faculty_Student.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection _services)
    {
        _services.AddScoped<IUserServices, UserServices>();
    }
}
