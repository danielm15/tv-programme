using System;

namespace TVP.Models.Entities
{
    public class ProgrammeItem
    {
        public string midill { get; set; } 
        public string midill_heiti { get; set; } 
        public DateTime dagsetning { get; set; } 
        public DateTime upphaf { get; set; } 
        public string titill { get; set; } 
        public string isltitill { get; set; } 
        public string undirtitill { get; set; } 
        public int seria { get; set; } 
        public int thattur { get; set; } 
        public int thattafjoldi { get; set; } 
        public int birta_thatt { get; set; } 
        public int opin { get; set; } 
        public int beint { get; set; } 
        public int frumsyning { get; set; } 
        public int framundan_i_beinni { get; set; } 
        public string tegund { get; set; } 
        public string flokkur { get; set; } 
        public string adalhlutverk { get; set; } 
        public string leikstjori { get; set; } 
        public string ar { get; set; } 
        public string bannad { get; set; } 
        public int? recidefni { get; set; } 
        public int? recidlidur { get; set; } 
        public int? recidsyning { get; set; } 
        public int? refno { get; set; } 
        public int frelsi { get; set; } 
        public int netdagar { get; set; } 
        public string lysing { get; set; } 
        public int slott { get; set; } 
        public string slotlengd { get; set; } 
    }
}
