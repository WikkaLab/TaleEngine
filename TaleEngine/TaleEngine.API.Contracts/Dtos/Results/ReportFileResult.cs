namespace TaleEngine.API.Contracts.Dtos.Results
{
    public class ReportFileResult
    {
        public byte[] Content { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
    }
}
