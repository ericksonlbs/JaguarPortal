using System.ComponentModel.DataAnnotations;

namespace JaguarPortal.WebApi.Models.Request
{
    public class AnalysisInsertRequest
    {
        public long IdProject { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Version { get; set; }
        public string Heuristic { get; set; }
        public int TotalTests { get; set; }
        public int FailedTests { get; set; }

        public List<SpectrumInsertRequest> Spectrums { get; set; }
    }

    public class SpectrumInsertRequest
    {
        public int Line { get; set; }
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public int CEF { get; set; }
        public int CEP { get; set; }
        public int CNF { get; set; }
        public int CNP { get; set; }
    }
}
