using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using TVP.Models.Entities;

namespace TVP.Repositories.Interfaces
{
    public interface IApiDataCollector
    {
        Task<IEnumerable<String>> GetStod2Channels();
        Task<IEnumerable<ProgrammeItem>> GetStod2ProgrammeForChannel(string channel);
        Task<IEnumerable<RuvProgrammeItem>> GetRUVProgramme();
    }
}