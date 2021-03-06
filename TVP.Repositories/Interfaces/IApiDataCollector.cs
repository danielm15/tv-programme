using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using TVP.Models.Dtos;

namespace TVP.Repositories.Interfaces
{
    public interface IApiDataCollector
    {
        Task<IEnumerable<String>> GetStod2Channels();
        Task<IEnumerable<ProgrammeItemDto>> GetStod2ProgrammeForChannel(string channel);
        Task<IEnumerable<RuvProgrammeItemDto>> GetRUVProgramme();
    }
}