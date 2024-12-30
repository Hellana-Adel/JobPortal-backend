namespace Job_Portal.DAL
{
    public class Job
    {
        public int JobId { get; set; } 
        public string Title { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;

        public JobDetails JobDetails { get; set; } = null!;
        public ICollection<ApplyForm> Applications { get; set; } = new List<ApplyForm>();
    }

}
