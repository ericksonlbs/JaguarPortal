using JaguarPortal.Core.Exceptions;
using JaguarPortal.Core.Interfaces;
using JaguarPortal.Core.Models;
using JaguarPortal.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace JaguarPortal.Core.Repositories
{
    public class AnalysisService : IAnalysisService
    {
        private readonly ILogger<AnalysisService> logger;
        private readonly IUnitOfWork unitOfWork;

        public AnalysisService(ILogger<AnalysisService> logger, IUnitOfWork unitOfWork)
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Analysis>> GetList()
        {
            return await unitOfWork.Analyses.GetAll();
        }

        public async Task<Analysis> GetById(long id)
        {
            Analysis? analysis = await unitOfWork.Analyses.GetById(id);
            if (analysis is null)
            {
                logger.LogInformation("Analysis not found");
                throw new NotFoundObjectException("Analysis not found");
            }

            analysis.Spectrums = await unitOfWork.Spectrums.GetByAnalysis(id);
            return analysis;
        }

        public async Task Insert(Analysis obj)
        {
            obj.CreatedDate = DateTime.UtcNow;

            await unitOfWork.Analyses.Add(obj);
            unitOfWork.Save();
            logger.LogInformation("Analysis inserted");
        }

        public async Task Delete(long id)
        {
            Analysis? analysis = await unitOfWork.Analyses.GetById(id);
            if (analysis is null)
                throw new NotFoundObjectException("Analysis not found");
            unitOfWork.Analyses.Delete(analysis);
            unitOfWork.Save();
            logger.LogInformation("Analysis {id} deleted", id);
        }

    }
}
