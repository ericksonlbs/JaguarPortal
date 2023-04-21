using static System.Net.Mime.MediaTypeNames;

namespace JaguarWebAPI.Models
{
    public class HeuristicDataModel
    {
        /// <summary>
        /// count (C) of tests that executed (E) this spectrum and the test failed(F).
        /// </summary>
        public int Cef { get; set; }

        /// <summary>
        /// count (C) of tests that NOT (N) executed this spectrum and the test failed(F).
        /// </summary>
        public int Cnf { get; set; }

        /// <summary>
        /// count(C) of tests that executed(E) this spectrum and the test passed(P).
        /// </summary>
        public int Cep { get; set; }

        /// <summary>
        /// count (C) of tests that NOT (N) executed this spectrum and the test passed(P).
        /// </summary>
        public int Cnp { get; set; }
    }
}
