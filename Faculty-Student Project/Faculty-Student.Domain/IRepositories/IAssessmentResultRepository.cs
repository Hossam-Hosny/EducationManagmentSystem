using Faculty_Student.Domain.Entities;

namespace Faculty_Student.Domain.IRepositories;

public interface IAssessmentResultRepository
{
    Task<int> InsertAssessmentResult(ASSESSMENTRESULTS aSSESSMENTRESULTS);
}
