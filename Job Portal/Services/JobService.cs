using Microsoft.EntityFrameworkCore;
using Job_Portal.ServicesContracts;
using Job_Portal.DAL;
using Job_Portal.DTO;
using System;
using System.IO;
using System.Threading.Tasks;

public class JobService : IJob
{
    private readonly JobPortalDbContext _context;

    public JobService(JobPortalDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<JobDTO>> GetJobsAsync()
    {
        try
        {
            var jobs = await _context.Jobs.ToListAsync();
            var jobDtos = jobs.Select(job => new JobDTO
            {
                JobId = job.JobId,
                Title = job.Title,
                Company = job.Company,
                Location = job.Location
            });
            return jobDtos;
        }
        catch (Exception ex)
        {
            return Enumerable.Empty<JobDTO>(); 
        }
    }

    public async Task<JobDetailsDTO?> GetJobDetailsAsync(int jobId)
    {
        try
        {
            var jobDetails = await _context.Jobs
                .Include(j => j.JobDetails)
                .Where(j => j.JobId == jobId)
                .FirstOrDefaultAsync();

            if (jobDetails == null)
                return null;

            JobDetailsDTO result = new JobDetailsDTO
            {
                Title = jobDetails.Title,
                Company = jobDetails.Company,
                Location = jobDetails.Location,
                Description = jobDetails.JobDetails.Description,
                Requirements = jobDetails.JobDetails.Requirements,
                PostedDate = jobDetails.JobDetails.PostedDate
            };

            return result;
        }
        catch (Exception ex)
        {
            return null; 
        }
    }

    public async Task<bool> JobApplyForm(ApplyFormDTO form)
    {
        try
        {
            var job = await _context.Jobs.FirstOrDefaultAsync(j => j.JobId == form.JobId);
            if (job == null)
                return false;

            if (form.Resume != null)
            {
                if (form.Resume.Length > 10 * 1024 * 1024)
                {
                    return false; 
                }

                using (var memoryStream = new MemoryStream())
                {
                    await form.Resume.CopyToAsync(memoryStream);
                    var fileBytes = memoryStream.ToArray();

                    ApplyForm applyForm = new ApplyForm
                    {
                        ApplicantEmail = form.ApplicantEmail,
                        ApplicantName = form.ApplicantName,
                        AppliedDate = DateTime.Now,
                        JobId = job.JobId,
                        ResumePath = fileBytes 
                    };

                    _context.ApplyForms.Add(applyForm);
                    await _context.SaveChangesAsync();
                }

                return true;
            }
            return false; 
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}
