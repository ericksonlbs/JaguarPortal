using System.Collections.Generic;
using System.Threading.Tasks;
using JaguarWebAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace JaguarWebAPI.Services
{
    public class AnalysisControlFlowService
    {
        private readonly IMongoCollection<AnalysisControlFlowModel> _analysisControlFlowCollection;

        public AnalysisControlFlowService(
            IOptions<Infrastructure.MongoDatabaseSettings> AnalysisControlFlowStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                AnalysisControlFlowStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                AnalysisControlFlowStoreDatabaseSettings.Value.DatabaseName);

            _analysisControlFlowCollection = mongoDatabase.GetCollection<AnalysisControlFlowModel>(
                AnalysisControlFlowStoreDatabaseSettings.Value.AnalysisControlFlowCollectionName);
        }

        public async Task<List<AnalysisControlFlowModel>> GetAsync() =>
            await _analysisControlFlowCollection.Find(_ => true).ToListAsync();

        public async Task<AnalysisControlFlowModel> GetAsync(string id) =>
            await _analysisControlFlowCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(AnalysisControlFlowModel newAnalysisControlFlow) =>
            await _analysisControlFlowCollection.InsertOneAsync(newAnalysisControlFlow);

        public async Task UpdateAsync(string id, AnalysisControlFlowModel updatedAnalysisControlFlow) =>
            await _analysisControlFlowCollection.ReplaceOneAsync(x => x.Id == id, updatedAnalysisControlFlow);

        public async Task RemoveAsync(string id) =>
            await _analysisControlFlowCollection.DeleteOneAsync(x => x.Id == id);
    }
}