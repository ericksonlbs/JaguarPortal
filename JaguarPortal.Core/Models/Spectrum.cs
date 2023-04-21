using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaguarPortal.Core.Models
{
    [Table("spectrums")]
    [ComplexType]
    public class Spectrum
    {
        [Key]
        public long Id { get; set; }
        [ForeignKey("Analysis")]
        public long AnalysisId { get; set; }
        public virtual Analysis Analysis { get; set; }
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
