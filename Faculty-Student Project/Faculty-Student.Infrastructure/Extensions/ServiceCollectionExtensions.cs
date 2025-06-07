using Faculty_Student.Domain.IRepositories;
using Faculty_Student.Infrastructure.DbContext;
using Faculty_Student.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Faculty_Student.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure( this IServiceCollection _servicecs)
    {
        _servicecs.AddScoped<IDbContext, AppDbContext>();


        _servicecs.AddScoped<IUserRepository, UserRepository>();
        _servicecs.AddScoped<ISubmissionRepository, SubmissionRepository>();
        _servicecs.AddScoped<IAssignmentRepository, AssignmentRepository>();
        _servicecs.AddScoped<IAssessmentResultRepository, AssessmentResultRepository>();
        _servicecs.AddScoped<IAssessmentCriteriaRepository, AssessmentCriteriaRepository>();
        _servicecs.AddScoped<IStudentRepository, StudentRepository>();
    
    }
}
