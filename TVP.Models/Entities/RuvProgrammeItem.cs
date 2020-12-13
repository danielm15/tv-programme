using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TVP.Models.Entities
{
    public class Series    
    {
        public string episode { get; set; } 
        public string series { get; set; } 
    }

    public class RuvProgrammeItem   
    {
        public string title { get; set; } 
        public string originalTitle { get; set; } 
        public string duration { get; set; } 
        public string description { get; set; } 
        public string shortDescription { get; set; } 
        public bool live { get; set; } 
        public bool premier { get; set; } 
        public string startTime { get; set; } 
        public string aspectRatio { get; set; } 
        public Series series { get; set; } 
    }

    public class RuvProgrammeList
    {
        public List<RuvProgrammeItem> results { get; set; } 
    }
}