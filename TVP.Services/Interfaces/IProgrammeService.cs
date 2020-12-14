using System.Collections.Generic;
using TVP.Models.Dtos;
using System.Threading.Tasks;

namespace TVP.Services.Interfaces
{
    public interface IProgrammeService
    {
        Task<IEnumerable<ProgrammeItemDto>> GetStod2ProgrammeForChannel(string channel);
        Task<IEnumerable<RuvProgrammeItemDto>> GetRUVProgramme();
    }
}