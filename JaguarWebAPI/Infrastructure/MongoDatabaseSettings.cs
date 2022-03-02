namespace JaguarWebAPI.Infrastructure
{
    public class MongoDatabaseSettings
    { 
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string AnalysisControlFlowCollectionName { get; set; } = null!;

    }
}