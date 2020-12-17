using System.Collections.Generic;
using System;
using TVP.Models.Dtos;
using System.Threading.Tasks;

namespace TVP.Services.Interfaces
{
    public interface IProgrammeService
    {
        Task<IEnumerable<String>> GetStod2Channels();
        Task<IEnumerable<ProgrammeItemDto>> GetStod2ProgrammeForChannel(string channel);
        Task<IEnumerable<RuvProgrammeItemDto>> GetRUVProgramme();
        IEnumerable<ProgrammeItemDto> FilterProgrammeByDate(IEnumerable<ProgrammeItemDto> programmeList, DateTime inputDate);
    }
}