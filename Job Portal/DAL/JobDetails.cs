namespace Job_Portal.DAL
{
    public class JobDetails
    {
        public int JobDetailsId { get; set; } 
        public string Description { get; set; } = string.Empty;
        public string Requirements { get; set; } = string.Empty;
        public DateTime PostedDate { get; set; } = DateTime.Now;

        public int JobId { get; set; }
        public Job Job { get; set; } = null!;
    }

}
