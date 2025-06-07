namespace Faculty_Student.Domain.Dtos;

public class StudentSymmaryDto
{
  
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int SubmissionCount { get; set; }
    

}
