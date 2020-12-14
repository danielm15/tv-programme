using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using TVP.Models.Entities;
using TVP.Models.Dtos;
using TVP.Repositories.Interfaces;
using AutoMapper;

namespace TVP.Repositories.Implementations
{
    // Retrieve programme information from stod2 web api
    public class ApiDataCollector : IApiDataCollector
    {
        private const string _stod2url = "https://api.stod2.is/dagskra/api/";
        private const string _ruvurl = "http://apis.is/tv/ruv";
        private HttpClient _client;
        private IMapper _mapper;

        public ApiDataCollector(IMapper mapper)
        {
            _mapper = mapper;
            _client = new HttpClient();
        }

        // Retrieves list of channels from Stöð2 API
        public async Task<IEnumerable<String>> GetStod2Channels()
        {
            var response = await _client.GetAsync($"{_stod2url}");

            if(response.StatusCode == HttpStatusCode.NotFound)
            {
                return Enumerable.Empty<String>();
            }

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<String>>(content);
        }

        // Retrieves the programme list from Stöð2 API
        public async Task<IEnumerable<ProgrammeItemDto>> GetStod2ProgrammeForChannel(string channel)
        {
            var response = await _client.GetAsync($"{_stod2url + channel}");

            if(response.StatusCode == HttpStatusCode.NotFound)
            {
                return Enumerable.Empty<ProgrammeItemDto>();
            }

            var content = await response.Content.ReadAsStringAsync();

            // Convert JSON string to entity object list.
            var entityList = JsonConvert.DeserializeObject<List<ProgrammeItem>>(content);

            // Map entity objects to DTO's and return the list.
            return _mapper.Map<IEnumerable<ProgrammeItemDto>>(entityList);
        }

        // Retrieves root JSON object from RÚV API and returns the programme list
        public async Task<IEnumerable<RuvProgrammeItemDto>> GetRUVProgramme()
        {
            var response = await _client.GetAsync($"{_ruvurl}");

            if(response.StatusCode == HttpStatusCode.NotFound)
            {
                return Enumerable.Empty<RuvProgrammeItemDto>();
            }

            var content = await response.Content.ReadAsStringAsync();

            // Convert JSON string to entity object list.
            var entityList = JsonConvert.DeserializeObject<RuvProgrammeList>(content).results;

            // Map entity objects to DTO's and return the list.
            return _mapper.Map<IEnumerable<RuvProgrammeItemDto>>(entityList);
        }
    }
}