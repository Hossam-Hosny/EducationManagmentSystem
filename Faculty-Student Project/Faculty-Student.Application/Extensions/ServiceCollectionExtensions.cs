using Faculty_Student.Application.Assessments.AssessmentCriteria.ServiceContracts;
using Faculty_Student.Application.Assessments.AssessmentCriteria.Services;
using Faculty_Student.Application.Assessments.AssessmentResult.ServiceContracts;
using Faculty_Student.Application.Assessments.AssessmentResult.Services;
using Faculty_Student.Application.Assignments.ServiceContracts;
using Faculty_Student.Application.Assignments.Services;
using Faculty_Student.Application.Student.Service;
using Faculty_Student.Application.Student.ServiceContracts;
using Faculty_Student.Application.Submissions.ServiceContracts;
using Faculty_Student.Application.Submissions.Services;
using Faculty_Student.Application.Users.ServiceContracts;
using Faculty_Student.Application.Users.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Faculty_Student.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection _services)
    {
        _services.AddScoped<IUserServices, UserServices>();
        _services.AddScoped<IAssignmentService, AssignmentServices>();
        _services.AddScoped<IAssessmentCriteriaService, AssessmentCriteriaService>();
        _services.AddScoped<IAssessmentResultService, AssessmentResultService>();
        _services.AddScoped<IStudentService, StudentService>();
        _services.AddScoped<ISubmissionService, SubmissionService>();

    }
}
