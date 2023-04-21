using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaguarPortal.WebApi.Client.Interfaces
{
    public interface IClientConfig
    {
        public Uri BaseUrl { get; set; }

        public int Timeout { get; set; }
    }
}
