namespace Job_Portal.DTO
{
    public class JobDTO
    {
        public int JobId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
    }
}
