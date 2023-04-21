using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JaguarPortal.Core.Models
{
    [Table("analyses")]
    public class Analysis
    {
        [Key]
        public long Id { get; set; }
        public long IdProject { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Version { get; set; }
        public string Heuristic { get; set; }
        public int TotalTests { get; set; }
        public int FailedTests { get; set; }

        public virtual IEnumerable<Spectrum> Spectrums { get; set; }
    }
}
