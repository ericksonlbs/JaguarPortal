using JaguarPortal.Core.Exceptions;
using JaguarPortal.Core.Interfaces;
using JaguarPortal.Core.Models;
using JaguarPortal.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace JaguarPortal.Core.Repositories
{
    public class SpectrumService : ISpectrumService
    {
        private readonly ILogger<SpectrumService> logger;
        private readonly IUnitOfWork unitOfWork;

        public SpectrumService(ILogger<SpectrumService> logger, IUnitOfWork unitOfWork)
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Spectrum>> GetList()
        {
            return await unitOfWork.Spectrums.GetAll();
        }

        public async Task<Spectrum> GetById(long id)
        {
            Spectrum? proj = await unitOfWork.Spectrums.GetById(id);
            if (proj is null)
            {
                logger.LogInformation("Spectrum not found");
                throw new NotFoundObjectException("Spectrum not found");
            }

            return proj;
        }

        public async Task Insert(Spectrum obj)
        {
            await unitOfWork.Spectrums.Add(obj);
            unitOfWork.Save();
            logger.LogInformation("Spectrum {Name} add", obj.Id);
        }

        public async Task Delete(long id)
        {
            Spectrum? Spectrum = await unitOfWork.Spectrums.GetById(id);
            if (Spectrum is null)
                throw new NotFoundObjectException("Spectrum not found");
            unitOfWork.Spectrums.Delete(Spectrum);
            unitOfWork.Save();
            logger.LogInformation("Spectrum {id} deleted", id);
        }

        public async Task<IEnumerable<Spectrum>> GetByAnalysis(long analysisId)
        {
            return await unitOfWork.Spectrums.GetByAnalysis(analysisId);
        }

        public Task Update(long id, Spectrum obj)
        {
            throw new NotImplementedException();
        }
    }
}
