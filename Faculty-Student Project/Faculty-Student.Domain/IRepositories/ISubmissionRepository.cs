using Faculty_Student.Domain.Entities;

namespace Faculty_Student.Domain.IRepositories;

public interface ISubmissionRepository
{
    Task<int> InsertSubmissionAsync(SUBMISSIONS sUBMISSIONS);
}
