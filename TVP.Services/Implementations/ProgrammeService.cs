using TVP.Services.Interfaces;
using TVP.Repositories.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using TVP.Models.Dtos;

namespace TVP.Services.Implementations
{
    public class ProgrammeService : IProgrammeService
    {
        private readonly IApiDataCollector _apiDataCollector;

        public ProgrammeService(IApiDataCollector apiDataCollector)
        {
            _apiDataCollector = apiDataCollector;
        }

        public async Task<IEnumerable<ProgrammeItemDto>> GetStod2ProgrammeForChannel(string channel)
        {
            return await _apiDataCollector.GetStod2ProgrammeForChannel(channel);
        }

        public async Task<IEnumerable<RuvProgrammeItemDto>> GetRUVProgramme()
        {
            return await _apiDataCollector.GetRUVProgramme();
        }
    }
}