using System.Collections.Generic;
using TVP.Models.Dtos;
using System;

namespace TVP.WebApp.Models
{
    public class IndexViewModel
    {
        public IEnumerable<String> channelList { get; set; }
        public IEnumerable<ProgrammeItemDto> programmeList { get; set; }
        public IEnumerable<RuvProgrammeItemDto> ruvProgrammeList { get; set; }

        public String currentChannel { get; set; }
        public DateTime currentDate { get; set; }

        // Allow for selection to persist through partial view updates
        public List<SelectedDate> selectedDate { get; set; }
        public List<SelectedChannel> selectedChannel { get; set; }
    }

    public class SelectedDate
    {
        private DateTime _date;
        private bool _isSelected;

        public DateTime Date { get { return _date; } set { _date = value; } }
        public bool IsSelected { get { return _isSelected; } set { _isSelected = value; } }
    }

    public class SelectedChannel
    {
        private String _channelName;
        private bool _isSelected;

        public String ChannelName { get { return _channelName; } set { _channelName = value; } }
        public bool IsSelected { get { return _isSelected; } set { _isSelected = value; } }
    }
}