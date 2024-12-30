using Microsoft.AspNetCore.Mvc;
using Job_Portal.ServicesContracts;
using Job_Portal.DAL;
using Job_Portal.DTO;

[ApiController]
[Route("api/[controller]")]
public class JobsController : Controller
{
    private readonly IJob _jobService;

    public JobsController(IJob jobService)
    {
        _jobService = jobService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<JobDTO>>> GetJobs()
    {
        var jobs = await _jobService.GetJobsAsync();
        return Ok(jobs);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetJobDetails(int id)
    {
        var jobDetails = await _jobService.GetJobDetailsAsync(id);

        if (jobDetails == null)
        {
            return NotFound(new { message = "Job not found" });
        }
        return Ok(jobDetails);
    }

    [HttpPost]
    public async Task<IActionResult> JobApplyForm(ApplyFormDTO form)
    {
        var result = await _jobService.JobApplyForm(form);

        if (result == true)
        {
            return Ok(); 
        }
        else if (result == false)
        {
            return BadRequest("File size is too large or other error occurred.");
        }
        return BadRequest("Invalid form data.");
    }

}
