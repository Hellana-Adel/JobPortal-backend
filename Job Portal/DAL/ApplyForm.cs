namespace Job_Portal.DAL
{
    public class ApplyForm
    {
        public int ApplyFormId { get; set; }
        public string ApplicantName { get; set; } = string.Empty;
        public string ApplicantEmail { get; set; } = string.Empty;
        public byte[]? ResumePath { get; set; } 
        public DateTime AppliedDate { get; set; } = DateTime.Now;

        public int JobId { get; set; }
        public Job Job { get; set; } = null!;
    }

}
