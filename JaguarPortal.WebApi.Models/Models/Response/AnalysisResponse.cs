using System.ComponentModel.DataAnnotations;

namespace JaguarPortal.WebApi.Models.Response
{
    public class AnalysisResponse
    {
        public long Id { get; set; }
        public long IdProject { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Version { get; set; }
        public string Heuristic { get; set; }
        public int TotalTests { get; set; }
        public int FailedTests { get; set; }

        public virtual IEnumerable<SpectrumResponse> Spectrums { get; set; }

    }
    public class SpectrumResponse
    {
        public int Line { get; set; }
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public int CEF { get; set; }
        public int CEP { get; set; }
        public int CNF { get; set; }
        public int CNP { get; set; }
        public string? FileRef { get; set; }
    }
}
