using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TVP.WebApp.Models;
using TVP.Models.Dtos;
using TVP.Services.Interfaces;

namespace TVP.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProgrammeService _programmeService;
        private IndexViewModel _indexViewModel;
        private  List<String> _channelList;
        private bool _isFirst;

        public HomeController(IProgrammeService programmeService)
        {
            _programmeService = programmeService;
            _indexViewModel = new IndexViewModel();
            _isFirst = true;
            _indexViewModel.selectedDate = new List<SelectedDate>();
            _indexViewModel.selectedChannel = new List<SelectedChannel>();
            _indexViewModel.currentChannel = "beint";
            _indexViewModel.currentDate = DateTime.Today;
            _channelList = new List<String>()
            {
                "beint",
                "bio",
                "esport",
                "golfstodin",
                "sport",
                "sport2",
                "sport3",
                "sport4",
                "sport5",
                "stod2",
                "stod3"
            };

            // Initialize list to store which date is selected
            // Set today as default date
            initalizeSelectedDateList();

            // Initalize list to store which channel is selected
            // Set first channel as default channel
            initializeSelectedChannelList();
        }

        public async Task<IActionResult> Index()
        {
            var defaultChannel = GetSelectedChannel();

            var defaultDate = GetSelectedDate();
                              
            var programmeList = await _programmeService.GetStod2ProgrammeForChannel(defaultChannel);
            
            _indexViewModel.programmeList = _programmeService.FilterProgrammeByDate(
                programmeList, defaultDate);

            return View(_indexViewModel);
        }

        [HttpGet("/Home/GetStod2Programme/{channelName}/{inputDate}")]
        public async Task<PartialViewResult> GetStod2Programme([FromRoute] String channelName, [FromRoute] String inputDate)
        {
            var programmeList = await _programmeService.GetStod2ProgrammeForChannel(channelName);

            _indexViewModel.currentChannel = channelName;
            SetSelectedChannel(channelName);

            _indexViewModel.currentDate = Convert.ToDateTime(inputDate);
            SetSelectedDate(_indexViewModel.currentDate);

            _indexViewModel.programmeList = _programmeService.FilterProgrammeByDate(
                programmeList, _indexViewModel.currentDate);

            _indexViewModel.ruvProgrammeList = null;

            return PartialView("_ProgrammeList", _indexViewModel);
        }

        public async Task<PartialViewResult> GetRuvProgramme()
        {
            var ruvProgrammeList = await _programmeService.GetRUVProgramme();

            _indexViewModel.ruvProgrammeList = ruvProgrammeList;

            return PartialView("_ProgrammeList", _indexViewModel);
        }

        public DateTime GetSelectedDate()
        {
            foreach(var item in _indexViewModel.selectedDate)
            {
                if(item.IsSelected) return item.Date;
            }
            return DateTime.Today;
        }

        public String GetSelectedChannel()
        {
            foreach(var item in _indexViewModel.selectedChannel)
            {
                if(item.IsSelected) return item.ChannelName;
            }
            return "beint";
        }

        public void SetSelectedChannel(String channel)
        {
            foreach (var item in _indexViewModel.selectedChannel)
            {
                if(item.IsSelected && item.ChannelName == channel)
                {
                    item.IsSelected = true;
                }
                else if(item.IsSelected)
                {
                    item.IsSelected = false;
                }
                else if(item.ChannelName == channel)
                {
                    item.IsSelected = true;
                }
            }
        }

        public void SetSelectedDate(DateTime selectedDate)
        {
            foreach (var item in _indexViewModel.selectedDate)
            {
                if(item.IsSelected && item.Date == selectedDate)
                {
                    item.IsSelected = true;
                }
                else if(item.IsSelected)
                {
                    item.IsSelected = false;
                }
                else if(item.Date == selectedDate)
                {
                    item.IsSelected = true;
                }
            }

        }

        private void initalizeSelectedDateList()
        {
            for(int i = 0; i < 8; i++)
            {
                if(i == 0) 
                { 
                    _indexViewModel.selectedDate.Add(new SelectedDate() 
                    {
                        Date = DateTime.Today.AddDays(i),
                        IsSelected = true
                    });
                }
                else 
                { 
                    _indexViewModel.selectedDate.Add(new SelectedDate() 
                    {
                        Date = DateTime.Today.AddDays(i),
                        IsSelected = false
                    });
                }
            }
        }

        private void initializeSelectedChannelList()
        {
            foreach(var channel in _channelList)
            {
                if(_isFirst)
                {
                    _indexViewModel.selectedChannel.Add(new SelectedChannel() 
                    {
                        ChannelName = channel,
                        IsSelected = true
                    });
                    _isFirst = false;
                }
                else
                {
                    _indexViewModel.selectedChannel.Add(new SelectedChannel() 
                    {
                        ChannelName = channel,
                        IsSelected = false
                    });  
                }
            }
        }
    }
}
