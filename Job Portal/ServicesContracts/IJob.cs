using Job_Portal.DAL;
using Job_Portal.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Job_Portal.ServicesContracts
{
    public interface IJob
    {
        Task<IEnumerable<JobDTO>> GetJobsAsync();
        Task<JobDetailsDTO?> GetJobDetailsAsync(int jobId);
        Task<bool> JobApplyForm(ApplyFormDTO Form);
    }
}
