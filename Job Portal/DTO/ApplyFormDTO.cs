namespace Job_Portal.DTO
{
    public class ApplyFormDTO
    {
        public int JobId { get; set; }
        public string ApplicantName { get; set; } = string.Empty;
        public string ApplicantEmail { get; set; } = string.Empty;
        public IFormFile Resume { get; set; }
    }
}
