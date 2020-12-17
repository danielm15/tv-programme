using TVP.Services.Interfaces;
using TVP.Repositories.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq;
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

        public async Task<IEnumerable<String>> GetStod2Channels()
        {
            return await _apiDataCollector.GetStod2Channels();
        }

        public async Task<IEnumerable<ProgrammeItemDto>> GetStod2ProgrammeForChannel(string channel)
        {
            return await _apiDataCollector.GetStod2ProgrammeForChannel(channel);
        }

        public async Task<IEnumerable<RuvProgrammeItemDto>> GetRUVProgramme()
        {
            return await _apiDataCollector.GetRUVProgramme();
        }

        public IEnumerable<ProgrammeItemDto> FilterProgrammeByDate(IEnumerable<ProgrammeItemDto> programmeList, DateTime inputDate)
        {
            return from item in programmeList
                where item.Date == inputDate
                select item;
        }
    }
}