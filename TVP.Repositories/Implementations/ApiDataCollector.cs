using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using TVP.Models.Entities;
using System;
using TVP.Repositories.Interfaces;

namespace TVP.Repositories.Implementations
{
    // Retrieve programme information from stod2 web api
    public class ApiDataCollector : IApiDataCollector
    {
        private const string _stod2url = "https://api.stod2.is/dagskra/api/";
        private const string _ruvurl = "http://apis.is/tv/ruv";
        private HttpClient _client;

        public ApiDataCollector()
        {
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
        public async Task<IEnumerable<ProgrammeItem>> GetStod2ProgrammeForChannel(string channel)
        {
            var response = await _client.GetAsync($"{_stod2url + channel}");

            if(response.StatusCode == HttpStatusCode.NotFound)
            {
                return Enumerable.Empty<ProgrammeItem>();
            }

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<ProgrammeItem>>(content);
        }

        // Retrieves root JSON object from RÚV API and returns the programme list
        public async Task<IEnumerable<RuvProgrammeItem>> GetRUVProgramme()
        {
            var response = await _client.GetAsync($"{_ruvurl}");

            if(response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<RuvProgrammeList>(content).results;

        }
    }
}